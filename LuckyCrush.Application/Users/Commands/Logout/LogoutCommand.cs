using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Users.Commands.Logout;

public class LogoutCommand : IRequest<Result>
{
    public string Token { get; set; } = default!;
}
