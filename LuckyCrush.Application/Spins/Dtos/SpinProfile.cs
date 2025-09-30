using AutoMapper;
using LuckyCrush.Application.Spins.Commands.Create;
using LuckyCrush.Domain.Entities.Wheels;

namespace LuckyCrush.Application.Spins.Dtos;

public class SpinProfile : Profile
{
    public SpinProfile()
    {
        CreateMap<Spin, SpinDto>()
            .ReverseMap();

        CreateMap<CreateSpinCommand, Spin>();
    }
}
