namespace LuckyCrush.Domain.Entities.Account;

public class Setting
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;
    public bool BackgroundMusic { get; set; }
    public bool SoundEffect { get; set; }
    public string Language { get; set; } = default!; // en or ar
    public bool PushNotification { get; set; }
}
