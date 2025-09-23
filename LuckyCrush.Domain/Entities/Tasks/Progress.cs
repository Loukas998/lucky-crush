using LuckyCrush.Domain.Entities.Account;

namespace LuckyCrush.Domain.Entities.Tasks;

public class Progress
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public User User { get; set; } = default!;
    public int GoalId { get; set; }
    public Goal Goal { get; set; } = default!;
    public int Amount { get; set; }
    public bool Completed { get; set; }
}
