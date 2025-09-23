using LuckyCrush.Domain.Entities.Account;

namespace LuckyCrush.Application.Unlockables.Dtos;

public class UnlockableProfile : AutoMapper.Profile
{
    public UnlockableProfile()
    {
        CreateMap<Unlockable, UnlockableDto>();

    }
}
