namespace LuckyCrush.Application.Users.Dtos;

public class BalanceDto
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public int Hearts { get; set; }
    public int Coins { get; set; }
    public int Diamonds { get; set; }
}
