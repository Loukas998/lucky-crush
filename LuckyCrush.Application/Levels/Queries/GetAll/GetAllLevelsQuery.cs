using LuckyCrush.Application.Levels.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Levels.Queries.GetAll;

public class GetAllLevelsQuery : IRequest<Result<IEnumerable<LevelDto>>>
{
}
