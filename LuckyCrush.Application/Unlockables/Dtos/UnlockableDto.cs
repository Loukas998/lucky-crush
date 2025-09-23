namespace LuckyCrush.Application.Unlockables.Dtos;

public class UnlockableDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!; // Style or Achievement 
    public string? ImagePath { get; set; }
}
