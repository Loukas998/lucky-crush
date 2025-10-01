using LuckyCrush.Application.Users.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Users.Commands.RefreshToken;

public class RefreshTokenCommand : IRequest<Result<LoginResponse>>
{
    public string RefreshToken { get; set; } = default!;
}
