using MediatR;

namespace LuckyCrush.Application.Rocks.Commands.Update;

public class UpdateRockCommand : IRequest
{
    public int RockId { get; set; }
    public string Name { get; set; } = default!;
    public string ImagePath { get; set; } = string.Empty;
}
