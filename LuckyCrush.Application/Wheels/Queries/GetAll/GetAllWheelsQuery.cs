using LuckyCrush.Application.Wheels.Dtos;
using MediatR;

namespace LuckyCrush.Application.Wheels.Queries.GetAll;

public class GetAllWheelsQuery : IRequest<IEnumerable<WheelDto>>
{
}
