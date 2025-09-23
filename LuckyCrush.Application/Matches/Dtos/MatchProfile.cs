using AutoMapper;
using LuckyCrush.Domain.Entities.Levels;

namespace LuckyCrush.Application.Matches.Dtos;

public class MatchProfile : Profile
{
    public MatchProfile()
    {
        CreateMap<MatchDto, Match>();
    }
}
