using LuckyCrush.Domain.Entities.Account;

namespace LuckyCrush.Domain.Repositories;

public interface ITokenRepository
{
    public Task<string> CreateRefreshToken(User user);
    public Task<(string AccessToken, string RefreshToken, int DurationInMinutes)?> VerifyRefreshToken(string userId, string refreshToken);
    public Task<(string AccessToken, string RefreshToken, int DurationInMinutes)?> Login(string userId);
    public Task TokenDelete(User user);
}
