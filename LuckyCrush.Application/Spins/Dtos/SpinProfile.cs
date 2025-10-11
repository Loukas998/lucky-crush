using AutoMapper;
using LuckyCrush.Application.Spins.Commands.Create;
using LuckyCrush.Domain.Entities.Wheels;

namespace LuckyCrush.Application.Spins.Dtos;

public class SpinProfile : Profile
{
    public SpinProfile()
    {
        CreateMap<Spin, SpinDto>()
            .ForMember(dest => dest.Prize, opt => opt.MapFrom(src => src.Prize))
            .ReverseMap();

        CreateMap<CreateSpinCommand, Spin>();
    }
}
