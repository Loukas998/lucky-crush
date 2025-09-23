using MediatR;

namespace LuckyCrush.Application.Users.Commands.Logout;

public class LogoutCommand : IRequest
{
    public string Token { get; set; }
}
