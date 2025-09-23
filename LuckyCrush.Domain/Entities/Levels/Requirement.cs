using LuckyCrush.Domain.Entities.Game;

namespace LuckyCrush.Domain.Entities.Levels;

public class Requirement
{
    public int LevelId { get; set; }
    public Level Level { get; set; } = default!;
    public int RockId { get; set; }
    public Rock Rock { get; set; } = default!;
    public int Quantity { get; set; }
}
