using LuckyCrush.Application.Spins.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Spins.Commands.Create;

public class CreateSpinCommand : IRequest<Result<SpinDto>>
{
    public int WheelId { get; set; } = default!;
    public string CorrelationId { get; set; } = default!;
}
