using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace LuckyCrush.Application.Users.Commands.CreateAccount;

public class CreateAccountCommand : IRequest<Result<IEnumerable<IdentityError>>>
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public byte[] ProfileImage { get; set; } = [];
}
