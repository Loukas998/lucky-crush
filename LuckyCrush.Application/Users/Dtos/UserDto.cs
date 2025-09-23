using LuckyCrush.Application.Users.Dtos;

namespace LuckyCrush.Application.Users.Profile;

public class UserDto
{
    public string? ProfileImagePath { get; set; }
    public bool IsSyncedWithFacebook { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public SettingDto Setting { get; set; } = default!;
    public ProfileDto Profile { get; set; } = default!;
    public BalanceDto Balance { get; set; } = default!;
}
