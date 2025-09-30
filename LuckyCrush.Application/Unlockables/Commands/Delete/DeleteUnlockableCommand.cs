using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Unlockables.Commands.Delete;

public class DeleteUnlockableCommand(int unlockableId) : IRequest<Result>
{
    public int UnlockableId { get; } = unlockableId;
}
