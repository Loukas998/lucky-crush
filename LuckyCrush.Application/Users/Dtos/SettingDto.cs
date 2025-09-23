namespace LuckyCrush.Application.Users.Dtos;

public class SettingDto
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public bool BackgroundMusic { get; set; }
    public bool SoundEffect { get; set; }
    public string Language { get; set; } = default!; // en or ar
    public bool PushNotification { get; set; }
}
