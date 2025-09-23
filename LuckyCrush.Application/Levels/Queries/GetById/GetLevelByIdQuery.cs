using LuckyCrush.Application.Levels.Dtos;
using MediatR;

namespace LuckyCrush.Application.Levels.Queries.GetById;

public class GetLevelByIdQuery : IRequest<LevelDto>
{
    public int LevelId { get; set; }
}
