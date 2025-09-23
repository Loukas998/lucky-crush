namespace LuckyCrush.Application.Users.Dtos;

public class ProfileDto
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public string? ProfileImage { get; set; }
    public string? UserName { get; set; }
    public int LevelsCompleted { get; set; }
    public int StarsCollected { get; set; }
    public int BoostersUsed { get; set; }
    public int CurrentLevel { get; set; }
    public int TotalCoinsEarned { get; set; }
}
