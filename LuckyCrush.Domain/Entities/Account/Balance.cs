namespace LuckyCrush.Domain.Entities.Account;

public class Balance
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;
    public int Hearts { get; set; }
    public int Coins { get; set; }
    public int Diamonds { get; set; }
}
