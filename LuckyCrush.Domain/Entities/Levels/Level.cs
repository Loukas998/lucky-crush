namespace LuckyCrush.Domain.Entities.Levels;

public class Level
{
    public int Id { get; set; }
    public int Number { get; set; }
    public bool IsSpecial { get; set; }
    public int RequiredStars { get; set; }

    public List<Trophy> Trophies { get; set; } = [];
    public List<Match> Matches { get; set; } = [];
    public List<Requirement> Requirements { get; set; } = [];
    public List<UserLevel> UserLevels { get; set; } = [];
}
