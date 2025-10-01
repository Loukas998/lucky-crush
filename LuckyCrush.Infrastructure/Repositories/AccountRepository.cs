using LuckyCrush.Domain.Entities.Account;
using LuckyCrush.Domain.Entities.Sessions;
using LuckyCrush.Domain.Entities.Wheels;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace LuckyCrush.Infrastructure.Repositories;

public class AccountRepository(UserManager<User> userManager, ApplicationDbContext dbContext) : IAccountRepository
{
    public async Task<Balance> GetPlayerBalanceAsync(string userId)
    {
        var user = await dbContext.Users
            .Include(u => u.Balance)
            .FirstOrDefaultAsync(u => u.Id == userId);

        return user!.Balance;
    }

    public async Task<IEnumerable<Prize>> GetPlayerPrizesAsync(string userId)
    {
        var user = await dbContext.Users
            .Include(u => u.Prizes)
            .FirstOrDefaultAsync(u => u.Id == userId);

        return user!.Prizes;
    }

    public async Task<Profile> GetPlayerProfileAsync(string userId)
    {
        var user = await dbContext.Users
            .Include(u => u.Profile)
            .FirstOrDefaultAsync(u => u.Id == userId);

        return user!.Profile;
    }

    public async Task<User?> GetUserByIdAsync(string userId)
    {
        return await userManager.FindByIdAsync(userId);
    }

    public async Task<User?> GetUserWithProgressAsync(string userId)
    {
        return await dbContext.Users
            .Include(u => u.Progresses)
            .FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<IEnumerable<IdentityError>> Register(User user, string role)
    {
        var existingUser = await dbContext.Users
            .FirstOrDefaultAsync(u => u.PhoneNumber == user.PhoneNumber);

        if (existingUser != null)
        {
            return new List<IdentityError>
                {
                    new IdentityError { Description = "This account already exists." }
                };
        }

        using var tx = await dbContext.Database.BeginTransactionAsync();

        user.UserName = GenerateName();
        user.Email = user.UserName + "@luckycrush.com";

        var result = await userManager.CreateAsync(user);
        if (!result.Succeeded)
        {
            return result.Errors;
        }

        //await userManager.AddToRoleAsync(user, role);

        var profile = new Profile
        {
            UserId = user.Id,
            BoostersUsed = 0,
            CurrentLevel = 1,
            LevelsCompleted = 0,
            StarsCollected = 0,
            TotalCoinsEarned = 0,
        };

        var balance = new Balance
        {
            UserId = user.Id,
            Coins = 1000,
            Diamonds = 1000,
            Hearts = 1000
        };

        var setting = new Setting
        {
            UserId = user.Id,
            BackgroundMusic = true,
            Language = "en",
            PushNotification = true,
            SoundEffect = true
        };

        dbContext.Profiles.Add(profile);
        dbContext.Balances.Add(balance);
        dbContext.Settings.Add(setting);

        await dbContext.SaveChangesAsync();
        await tx.CommitAsync();

        return Enumerable.Empty<IdentityError>();
    }

    public async Task<IEnumerable<IdentityError>> RegisterGoogle(User user)
    {
        var existingUser = await dbContext.Users
            .FirstOrDefaultAsync(u => u.PhoneNumber == user.PhoneNumber);

        if (existingUser != null)
        {
            return new List<IdentityError>
            {
                new IdentityError { Description = "This account already exists." }
            };
        }

        var result = await userManager.CreateAsync(user);
        if (!result.Succeeded)
        {
            return result.Errors;
        }

        return Enumerable.Empty<IdentityError>();
    }

    public async Task<bool> RevokeSession(string token)
    {
        var session = await dbContext.Sessions
            .FirstOrDefaultAsync(s => s.Token == token);

        if (session == null)
        {
            return false;
        }

        session.Revoked = true;
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<Otp> StoreOtp(Otp otp)
    {
        dbContext.Otps.Add(otp);
        await dbContext.SaveChangesAsync();
        return otp;
    }

    public async Task<string?> StoreSession(string phoneNumber)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);

        if (user != null)
        {
            var session = new Session
            {
                UserId = user.Id,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                Revoked = false,
                Token = Guid.NewGuid().ToString(),
            };

            dbContext.Sessions.Add(session);
            return session.Token;
        }

        return null;
    }

    public async Task<bool> VerifyOtp(string code, string phoneNumber)
    {
        var user = await dbContext.Users
            .Include(u => u.Otp)
            .FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);

        if (user == null || user.Otp == null)
        {
            return false;
        }

        var otp = user.Otp;
        if (otp.IsUsed || otp.ExpiresAt < DateTime.UtcNow || otp.Code != code)
        {
            return false;
        }

        otp.IsUsed = true;
        return true;
    }

    private string GenerateName()
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz123456789";
        StringBuilder result = new StringBuilder("New_");

        for (int i = 0; i < 5; i++)
        {
            result.Append(chars[random.Next(chars.Length)]);
        }

        return result.ToString();
    }
}
