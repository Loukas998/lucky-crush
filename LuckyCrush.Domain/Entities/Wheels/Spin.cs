using LuckyCrush.Domain.Entities.Account;

namespace LuckyCrush.Domain.Entities.Wheels;

public class Spin
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;
    public int WheelId { get; set; } = default!;
    public Wheel Wheel { get; set; } = default!;
    public DateTime SpinAt { get; set; }
    public string Type { get; set; } = default!; // Free, Paid
}
