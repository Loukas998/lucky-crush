namespace LuckyCrush.Domain.Entities.Account;

public class Unlockable
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!; // Style or Achievement 
    public string? ImagePath { get; set; }

    public List<User> Users { get; set; } = [];
}
