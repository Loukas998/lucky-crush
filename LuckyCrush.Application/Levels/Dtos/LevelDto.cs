namespace LuckyCrush.Application.Levels.Dtos;

public class LevelDto
{
    public int Id { get; set; }
    public int Number { get; set; }
    public bool IsSpecial { get; set; }
    public int RequiredStars { get; set; }
    public List<RequirementDto> Requirements { get; set; } = [];
}
