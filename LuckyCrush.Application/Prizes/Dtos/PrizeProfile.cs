using AutoMapper;
using LuckyCrush.Application.Prizes.Commands.Create;
using LuckyCrush.Application.Prizes.Commands.Update;
using LuckyCrush.Domain.Entities.Wheels;

namespace LuckyCrush.Application.Prizes.Dtos;

public class PrizeProfile : Profile
{
    public PrizeProfile()
    {
        CreateMap<Prize, PrizeDto>();

        CreateMap<CreatePrizeCommand, Prize>()
            .ForMember(dest => dest.Image, opt => opt.Ignore());

        CreateMap<UpdatePrizeCommand, Prize>()
            .ForMember(dest => dest.Image, opt => opt.Ignore());
    }
}
