using MediatR;

namespace LuckyCrush.Application.Unlockables.Commands.Update;

public class UpdateUnlockableCommand : IRequest
{
    public int UnlockableId { get; set; }
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!; // Style or Achievement 
    public string? ImagePath { get; set; }
}
