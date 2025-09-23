using LuckyCrush.Domain.Entities.Wheels;

namespace LuckyCrush.Domain.Entities.Account;

public class Inventory
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;
    public List<Prize> Prizes { get; set; } = default!;
}
