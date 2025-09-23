using LuckyCrush.Domain.Entities.Account;

namespace LuckyCrush.Domain.Entities.Levels;

public class Match
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;
    public int LevelId { get; set; }
    public Level Level { get; set; } = default!;
    public bool Won { get; set; }
    public int StarsCollected { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime EndedAt { get; set; }

    public List<Destruction> Destructions { get; set; } = [];
}
