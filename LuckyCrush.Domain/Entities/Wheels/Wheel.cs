namespace LuckyCrush.Domain.Entities.Wheels;

public class Wheel
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsActive { get; set; }
    public string Type { get; set; } = default!; // Daily, Ad, Diamond
    public List<Prize> Prizes { get; set; } = [];
    public List<Spin> Spins { get; set; } = [];
}
