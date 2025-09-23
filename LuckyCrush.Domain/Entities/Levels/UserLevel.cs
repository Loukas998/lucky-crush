using LuckyCrush.Domain.Entities.Account;

namespace LuckyCrush.Domain.Entities.Levels;

public class UserLevel
{
    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;
    public int LevelId { get; set; }
    public Level Level { get; set; } = default!;
    public DateTime? CompletedAt { get; set; }
    public int Attempts { get; set; }
    public int BestStars { get; set; }
}
