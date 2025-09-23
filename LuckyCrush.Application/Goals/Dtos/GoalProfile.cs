using AutoMapper;
using LuckyCrush.Domain.Entities.Tasks;

namespace LuckyCrush.Application.Goals.Dtos;

public class GoalProfile : Profile
{
    public GoalProfile()
    {
        CreateMap<Goal, GoalDto>()
            .ReverseMap();
    }
}
