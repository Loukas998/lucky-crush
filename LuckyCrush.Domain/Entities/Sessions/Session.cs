using LuckyCrush.Domain.Entities.Account;

namespace LuckyCrush.Domain.Entities.Sessions;

public class Session
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;
    public string Token { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public bool Revoked { get; set; }

}
