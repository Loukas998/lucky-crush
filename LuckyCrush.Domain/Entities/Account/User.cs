using LuckyCrush.Domain.Entities.Levels;
using LuckyCrush.Domain.Entities.Sessions;
using LuckyCrush.Domain.Entities.Tasks;
using LuckyCrush.Domain.Entities.Wheels;
using Microsoft.AspNetCore.Identity;

namespace LuckyCrush.Domain.Entities.Account;

public class User : IdentityUser
{
    public bool IsSyncedWithFacebook { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public Setting Setting { get; set; } = default!;
    public Profile Profile { get; set; } = default!;
    public Balance Balance { get; set; } = default!;
    public Otp Otp { get; set; } = default!;

    public List<Unlockable> Unlockables { get; set; } = [];
    public List<Progress> Progresses { get; set; } = [];
    public List<Match> Matches { get; set; } = [];
    public List<Spin> Spins { get; set; } = [];
    public List<Prize> Prizes { get; set; } = [];
    public List<Session> Sessions { get; set; } = [];
    public List<Reward> Rewards { get; set; } = [];
    public List<UserLevel> UserLevels { get; set; } = [];
}
