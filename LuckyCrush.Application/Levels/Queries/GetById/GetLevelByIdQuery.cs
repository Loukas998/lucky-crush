using LuckyCrush.Application.Levels.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Levels.Queries.GetById;

public class GetLevelByIdQuery : IRequest<Result<LevelDto>>
{
    public int LevelId { get; set; }
}
