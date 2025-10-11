using LuckyCrush.Application.Prizes.Dtos;

namespace LuckyCrush.Application.Spins.Dtos;

public class SpinDto
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public int WheelId { get; set; } = default!;
    public PrizeDto Prize { get; set; } = default!;
    public DateTime SpinAt { get; set; }
    public string Type { get; set; } = default!; // Free, Paid
}
