using LuckyCrush.Domain.Entities.Levels;

namespace LuckyCrush.Domain.Entities.Game;

public class Rock
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string ImagePath { get; set; } = string.Empty;
    public List<Requirement> Requirements { get; set; } = [];
    public List<Destruction> Destructions { get; set; } = [];
}
