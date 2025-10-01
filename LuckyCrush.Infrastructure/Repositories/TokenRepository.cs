using LuckyCrush.Domain.Entities.Account;
using LuckyCrush.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LuckyCrush.Infrastructure.Repositories;

public class TokenRepository(UserManager<User> userManager, IConfiguration configuration) : ITokenRepository
{
    private readonly int _expiresInMinutes =
            Convert.ToInt32(configuration["JwtSettings:DurationInMinutes"]) * 24;
    private readonly string _loginProvidor = "LuckyCrushTokenProvidor";
    private readonly string _refreshToken = "RefreshToken";

    public async Task<string> CreateRefreshToken(User user)
    {
        await userManager.RemoveAuthenticationTokenAsync(user!, _loginProvidor, _refreshToken);
        var newToken = await userManager.GenerateUserTokenAsync(user!, _loginProvidor, _refreshToken);
        var res = await userManager.SetAuthenticationTokenAsync(user!, _loginProvidor, _refreshToken, newToken);
        return newToken;
    }

    public async Task TokenDelete(User user)
    {
        await userManager.RemoveAuthenticationTokenAsync(user, _loginProvidor, _refreshToken);
        await userManager.UpdateSecurityStampAsync(user);
    }

    public async Task<(string AccessToken, string RefreshToken, int DurationInMinutes)?> VerifyRefreshToken(string userId, string refreshToken)
    {
        var existing = await userManager.FindByIdAsync(userId);
        if (existing is null)
        {
            return null;
        }

        var isValidRefreshToken = await userManager.VerifyUserTokenAsync(existing, _loginProvidor, _refreshToken, refreshToken);
        if (isValidRefreshToken)
        {
            return (
                AccessToken: await GenerateAccessToken(existing),
                RefreshToken: await CreateRefreshToken(existing),
                DurationInMinutes: _expiresInMinutes
             );
        }
        return null;
    }

    public async Task<(string AccessToken, string RefreshToken, int DurationInMinutes)?> Login(string userId)
    {
        var existing = await userManager.FindByIdAsync(userId);

        if (existing == null /*|| !_user.IsActive*/)
        {
            return null;
        }

        return (
            AccessToken: await GenerateAccessToken(existing),
            RefreshToken: await CreateRefreshToken(existing),
            DurationInMinutes: _expiresInMinutes
        );
    }

    private async Task<string> GenerateAccessToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var roleClaims = await userManager.GetRolesAsync(user);
        var roles = roleClaims.Select(x => new Claim(ClaimTypes.Role, x));

        var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                //new Claim(JwtRegisteredClaimNames.PhoneNumber, user.PhoneNumber!),

            }.Union(roles);

        var token = new JwtSecurityToken(
                issuer: configuration["JwtSettings:Issuer"],
                audience: configuration["JwtSettings:Audience"],
                signingCredentials: credentials,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(configuration["JwtSettings:DurationInMinutes"]))
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
