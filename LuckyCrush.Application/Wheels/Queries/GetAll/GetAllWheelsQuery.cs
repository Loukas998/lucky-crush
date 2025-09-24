using LuckyCrush.Application.Wheels.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Wheels.Queries.GetAll;

public class GetAllWheelsQuery : IRequest<Result<IEnumerable<WheelDto>>>
{
}
