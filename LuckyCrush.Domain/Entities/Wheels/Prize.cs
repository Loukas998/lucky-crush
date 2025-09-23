using LuckyCrush.Domain.Entities.Account;

namespace LuckyCrush.Domain.Entities.Wheels;

public class Prize
{
    public int Id { get; set; }
    public string Image { get; set; } = string.Empty;
    public int Weight { get; set; }
    public List<Wheel> Wheels { get; set; } = default!;
    public int CategoryId { get; set; }
    public Category Category { get; set; } = default!;
    public int Amount { get; set; }
    public List<User> Users { get; set; } = [];
}
