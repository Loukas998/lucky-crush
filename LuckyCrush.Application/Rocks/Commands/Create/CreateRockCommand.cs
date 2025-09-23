using MediatR;

namespace LuckyCrush.Application.Rocks.Commands.Create;

public class CreateRockCommand : IRequest<int>
{
    public string Name { get; set; } = default!;
    public string ImagePath { get; set; } = string.Empty;
}
