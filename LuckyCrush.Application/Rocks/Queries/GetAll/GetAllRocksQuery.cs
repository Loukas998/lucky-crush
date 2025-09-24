using LuckyCrush.Application.Rocks.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Rocks.Queries.GetAll;

public class GetAllRocksQuery : IRequest<Result<IEnumerable<RockDto>>>
{
}
