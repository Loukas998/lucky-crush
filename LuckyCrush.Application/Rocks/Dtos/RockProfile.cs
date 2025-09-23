using AutoMapper;
using LuckyCrush.Application.Rocks.Commands.Create;
using LuckyCrush.Application.Rocks.Commands.Update;
using LuckyCrush.Domain.Entities.Game;

namespace LuckyCrush.Application.Rocks.Dtos;

public class RockProfile : Profile
{
    public RockProfile()
    {
        CreateMap<Rock, RockDto>();

        CreateMap<CreateRockCommand, Rock>()
            .ForMember(dest => dest.ImagePath, opt => opt.Ignore());

        CreateMap<UpdateRockCommand, Rock>()
            .ForMember(dest => dest.ImagePath, opt => opt.Ignore());
    }
}
