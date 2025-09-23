using LuckyCrush.Application.Users.Dtos;
using LuckyCrush.Domain.Entities.Account;

namespace LuckyCrush.Application.Users.Profile;

public class UserProfile : AutoMapper.Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<Balance, BalanceDto>();
        CreateMap<Setting, SettingDto>();
        CreateMap<Domain.Entities.Account.Profile, ProfileDto>();


    }
}
