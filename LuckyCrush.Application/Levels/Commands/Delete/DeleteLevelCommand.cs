using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Levels.Commands.Delete;

public class DeleteLevelCommand(int levelId) : IRequest<Result>
{
    public int LevelId { get; } = levelId;
}
