namespace LuckyCrush.Domain.Entities.Levels
{
    public class Trophy
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int Amount { get; set; }
        public string? Image { get; set; }
        public int LevelId { get; set; }
        public Level Level { get; set; } = default!;
    }
}
