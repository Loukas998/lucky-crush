using AutoMapper;
using LuckyCrush.Application.Rewards.Commands.Create;
using LuckyCrush.Application.Rewards.Commands.Update;
using LuckyCrush.Domain.Entities.Tasks;

namespace LuckyCrush.Application.Rewards.Dtos;

public class RewardProfile : Profile
{
    public RewardProfile()
    {
        CreateMap<CreateRewardCommand, Reward>();
        CreateMap<UpdateRewardCommand, Reward>();
        CreateMap<Reward, RewardDto>()
            .ReverseMap();
    }
}
