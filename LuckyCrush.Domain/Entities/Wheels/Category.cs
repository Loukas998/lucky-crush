namespace LuckyCrush.Domain.Entities.Wheels;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public bool InGame { get; set; }
    public List<Prize> Prizes { get; set; } = [];
}
