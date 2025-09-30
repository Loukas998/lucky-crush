using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Unlockables.Commands.AssignToUser;

public class AssignUnlockableToUserCommand : IRequest<Result>
{
    public string UserId { get; set; } = string.Empty;
    public int UnlockableId { get; set; }
}
