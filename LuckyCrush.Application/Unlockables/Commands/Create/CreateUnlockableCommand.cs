using MediatR;

namespace LuckyCrush.Application.Unlockables.Commands.Create;

public class CreateUnlockableCommand : IRequest<int>
{
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!; // Style or Achievement 
    public string? ImagePath { get; set; }
}
