using LuckyCrush.Application.Levels.Dtos;
using MediatR;

namespace LuckyCrush.Application.Levels.Queries.GetAll;

public class GetAllLevelsQuery : IRequest<IEnumerable<LevelDto>>
{
}
