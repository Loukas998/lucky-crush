namespace LuckyCrush.Application.Matches.Dtos;

public class MatchDto
{
    public int Id { get; set; }
    public DateTime PlayedAt { get; set; } = DateTime.UtcNow;
    public string UserId { get; set; } = default!;
    public int LevelId { get; set; }
    public bool Won { get; set; }
    public int StarsCollected { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime EndedAt { get; set; }
}
