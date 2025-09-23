using AutoMapper;
using LuckyCrush.Application.Levels.Commands.Create;
using LuckyCrush.Application.Levels.Commands.Update;
using LuckyCrush.Domain.Entities.Levels;

namespace LuckyCrush.Application.Levels.Dtos;

public class LevelProfile : Profile
{
    public LevelProfile()
    {
        CreateMap<Level, LevelDto>();
        CreateMap<Requirement, RequirementDto>()
            .ReverseMap();

        CreateMap<CreateLevelCommand, Level>();
        CreateMap<UpdateLevelCommand, Level>();
    }
}
