using MediatR;

namespace LuckyCrush.Application.Levels.Commands.Delete;

public class DeleteLevelCommand : IRequest
{
    public int LevelId { get; set; }
}
