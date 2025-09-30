using LuckyCrush.Application.Levels.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Levels.Queries.GetById;

public class GetLevelByIdQuery(int levelId) : IRequest<Result<LevelDto>>
{
    public int LevelId { get; } = levelId;
}
