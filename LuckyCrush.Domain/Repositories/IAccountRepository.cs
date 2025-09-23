using LuckyCrush.Domain.Entities.Account;
using Microsoft.AspNetCore.Identity;

namespace LuckyCrush.Domain.Repositories;

public interface IAccountRepository
{
    public Task<IEnumerable<IdentityError>> Register(User user, string role);
    public Task<Otp> StoreOtp(Otp otp);
    public Task<bool> VerifyOtp(string code, string phoneNumber);
    public Task<string?> StoreSession(string phoneNumber);
    public Task<bool> RevokeSession(string token);
    public Task<User?> GetUserByIdAsync(string userId);
    public Task<User?> GetUserWithProgressAsync(string userId);
}
