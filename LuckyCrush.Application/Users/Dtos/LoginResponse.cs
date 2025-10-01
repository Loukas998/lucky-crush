namespace LuckyCrush.Application.Users.Dtos;

public class LoginResponse
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public int DurationInMinutes { get; set; }
}
