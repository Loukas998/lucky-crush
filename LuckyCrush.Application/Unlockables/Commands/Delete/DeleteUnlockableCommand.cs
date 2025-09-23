using MediatR;

namespace LuckyCrush.Application.Unlockables.Commands.Delete;

public class DeleteUnlockableCommand : IRequest
{
    public int UnlockableId { get; set; }
}
