using LuckyCrush.Application.Prizes.Dtos;

namespace LuckyCrush.Application.Wheels.Dtos;

public class WheelDto
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsActive { get; set; }
    public string Type { get; set; } = default!;
    public List<PrizeDto> Prizes { get; set; } = [];
}
