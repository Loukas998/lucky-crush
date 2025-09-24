using LuckyCrush.Application.Wheels.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Wheels.Queries.GetById;

public class GetWheelByIdQuery : IRequest<Result<WheelDto>>
{
    public int WheelId { get; set; }
}
