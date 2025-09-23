using LuckyCrush.Application.Spins.Dtos;
using MediatR;

namespace LuckyCrush.Application.Spins.Queries.GetAll;

public class GetAllSpinsQuery : IRequest<IEnumerable<SpinDto>>
{
}
