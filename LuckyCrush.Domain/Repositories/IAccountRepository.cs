using LuckyCrush.Domain.Entities.Account;
using LuckyCrush.Domain.Entities.Wheels;
using Microsoft.AspNetCore.Identity;

namespace LuckyCrush.Domain.Repositories;

public interface IAccountRepository
{
    public Task<IEnumerable<IdentityError>> Register(User user, string role);
    public Task<IEnumerable<IdentityError>> RegisterGoogle(User user);
    public Task<Otp> StoreOtp(Otp otp);
    public Task<bool> VerifyOtp(string code, string phoneNumber);
    public Task<string?> StoreSession(string phoneNumber);
    public Task<bool> RevokeSession(string token);
    public Task<User?> GetUserByIdAsync(string userId);
    public Task<User?> GetUserWithProgressAsync(string userId);
    public Task<Balance> GetPlayerBalanceAsync(string userId);
    public Task<Profile> GetPlayerProfileAsync(string userId);
    public Task<IEnumerable<Prize>> GetPlayerPrizesAsync(string userId);
    public Task<User?> GetUserWithPrizesAsync(string userId);
}
