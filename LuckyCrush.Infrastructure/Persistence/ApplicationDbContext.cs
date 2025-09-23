using LuckyCrush.Domain.Entities.Account;
using LuckyCrush.Domain.Entities.Game;
using LuckyCrush.Domain.Entities.Globals;
using LuckyCrush.Domain.Entities.Levels;
using LuckyCrush.Domain.Entities.Sessions;
using LuckyCrush.Domain.Entities.Tasks;
using LuckyCrush.Domain.Entities.Wheels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LuckyCrush.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<User>(options)
{
    // Account entities
    internal DbSet<Balance> Balances { get; set; }
    internal DbSet<Inventory> Inventories { get; set; }
    internal DbSet<Otp> Otps { get; set; }
    internal DbSet<Profile> Profiles { get; set; }
    internal DbSet<Setting> Settings { get; set; }
    internal DbSet<Unlockable> Unlockables { get; set; }
    internal DbSet<Session> Sessions { get; set; }
    internal DbSet<UserLevel> UserLevels { get; set; }

    // Global entities
    internal DbSet<GlobalType> Types { get; set; }

    // Level entities
    internal DbSet<Level> Levels { get; set; }
    internal DbSet<Match> Matches { get; set; }
    internal DbSet<Trophy> Trophies { get; set; }
    internal DbSet<Requirement> Requirements { get; set; }
    internal DbSet<Rock> Rocks { get; set; }
    internal DbSet<Destruction> Destructions { get; set; }

    // Task entities
    internal DbSet<Goal> Goals { get; set; }
    internal DbSet<Progress> Progresses { get; set; }
    internal DbSet<Reward> Rewards { get; set; }
    internal DbSet<Domain.Entities.Tasks.GoalTask> Tasks { get; set; }

    // Wheel entities
    internal DbSet<Category> Categories { get; set; }
    internal DbSet<Prize> Prizes { get; set; }
    internal DbSet<Spin> Spins { get; set; }
    internal DbSet<Wheel> Wheels { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // One to one
        builder.Entity<User>()
            .HasOne(u => u.Profile)
            .WithOne(p => p.User)
            .HasForeignKey<Profile>(p => p.UserId);

        builder.Entity<User>()
            .HasOne(u => u.Setting)
            .WithOne(s => s.User)
            .HasForeignKey<Setting>(s => s.UserId);

        builder.Entity<User>()
            .HasOne(u => u.Balance)
            .WithOne(b => b.User)
            .HasForeignKey<Balance>(b => b.UserId);

        builder.Entity<User>()
            .HasOne(u => u.Otp)
            .WithOne(o => o.User)
            .HasForeignKey<Otp>(o => o.UserId);

        // Many to many
        builder.Entity<User>()
            .HasMany(u => u.Unlockables)
            .WithMany(un => un.Users);

        builder.Entity<User>()
            .HasMany(u => u.Prizes)
            .WithMany(p => p.Users);

        builder.Entity<Wheel>()
            .HasMany(w => w.Prizes)
            .WithMany(p => p.Wheels);

        builder.Entity<User>()
            .HasMany(u => u.Rewards)
            .WithMany(r => r.Users);

        // One to many
        // Global type relations
        builder.Entity<GlobalType>()
            .HasMany(t => t.Rewards)
            .WithOne(r => r.Type)
            .HasForeignKey(r => r.TypeId);

        builder.Entity<GlobalType>()
            .HasMany(t => t.Tasks)
            .WithOne(t => t.Type)
            .HasForeignKey(t => t.TypeId);

        // User relations
        builder.Entity<User>()
            .HasMany(u => u.Progresses)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);

        builder.Entity<User>()
            .HasMany(u => u.Matches)
            .WithOne(m => m.User)
            .HasForeignKey(p => p.UserId);

        builder.Entity<User>()
            .HasMany(u => u.Spins)
            .WithOne(s => s.User)
            .HasForeignKey(p => p.UserId);

        builder.Entity<User>()
            .HasMany(u => u.Sessions)
            .WithOne(s => s.User)
            .HasForeignKey(s => s.UserId);

        builder.Entity<User>()
            .HasMany(u => u.UserLevels)
            .WithOne(ul => ul.User)
            .HasForeignKey(ul => ul.UserId);

        // Level relations
        builder.Entity<Level>()
            .HasMany(l => l.Matches)
            .WithOne(m => m.Level)
            .HasForeignKey(m => m.LevelId);

        builder.Entity<Level>()
            .HasMany(l => l.Trophies)
            .WithOne(t => t.Level)
            .HasForeignKey(t => t.LevelId);

        builder.Entity<Level>()
            .HasMany(l => l.Requirements)
            .WithOne(r => r.Level)
            .HasForeignKey(r => r.LevelId);

        builder.Entity<Match>()
            .HasMany(m => m.Destructions)
            .WithOne()
            .HasForeignKey(d => d.MatchId);

        builder.Entity<Rock>()
            .HasMany(r => r.Destructions)
            .WithOne()
            .HasForeignKey(d => d.RockId);

        builder.Entity<Rock>()
            .HasMany(r => r.Requirements)
            .WithOne(req => req.Rock)
            .HasForeignKey(req => req.RockId);

        builder.Entity<Level>()
            .HasMany(l => l.UserLevels)
            .WithOne(ul => ul.Level)
            .HasForeignKey(ul => ul.LevelId);

        // Goal relations
        builder.Entity<Goal>()
            .HasMany(g => g.Progresses)
            .WithOne(p => p.Goal)
            .HasForeignKey(p => p.GoalId);

        builder.Entity<GoalTask>()
            .HasMany(t => t.Goals)
            .WithOne(g => g.Task)
            .HasForeignKey(g => g.TaskId);

        // Wheel relations
        builder.Entity<Wheel>()
            .HasMany(w => w.Spins)
            .WithOne(s => s.Wheel)
            .HasForeignKey(s => s.WheelId);

        builder.Entity<Category>()
            .HasMany(c => c.Prizes)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);

        // Composite Keys
        builder.Entity<Requirement>()
            .HasKey(r => new { r.LevelId, r.RockId });

        builder.Entity<UserLevel>()
            .HasKey(ul => new { ul.LevelId, ul.UserId });

        builder.Entity<Destruction>()
            .HasKey(d => new { d.RockId, d.MatchId });
    }
}
