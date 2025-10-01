using LuckyCrush.Application.Users.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Users.Commands.Login;

public class LoginCommand : IRequest<Result<LoginResponse>>
{
    public string UserId { get; set; } = default!;
}
