using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Levels.Commands.Delete;

public class DeleteLevelCommand : IRequest<Result>
{
    public int LevelId { get; set; }
}
