using LuckyCrush.Application.Rocks.Dtos;
using MediatR;

namespace LuckyCrush.Application.Rocks.Queries.GetAll;

public class GetAllRocksQuery : IRequest<IEnumerable<RockDto>>
{
}
