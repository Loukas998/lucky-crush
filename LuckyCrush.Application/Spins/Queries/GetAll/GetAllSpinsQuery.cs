using LuckyCrush.Application.Spins.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Spins.Queries.GetAll;

public class GetAllSpinsQuery : IRequest<Result<IEnumerable<SpinDto>>>
{
}
