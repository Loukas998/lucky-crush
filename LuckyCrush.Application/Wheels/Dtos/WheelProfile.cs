using AutoMapper;
using LuckyCrush.Application.Wheels.Commands.Create;
using LuckyCrush.Domain.Entities.Wheels;

namespace LuckyCrush.Application.Wheels.Dtos;

public class WheelProfile : Profile
{
    public WheelProfile()
    {
        CreateMap<Wheel, WheelDto>()
            .ReverseMap();

        CreateMap<CreateWheelCommand, Wheel>();
    }
}
