namespace LuckyCrush.Domain.Entities.Account;

public class Otp
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;
    public string? Code { get; set; }
    public bool IsUsed { get; set; }
    public DateTime ExpiresAt { get; set; }
}
