using AutoMapper;
using LuckyCrush.Application.GlobalTypes.Commands.Create;
using LuckyCrush.Application.GlobalTypes.Commands.Update;
using LuckyCrush.Domain.Entities.Globals;

namespace LuckyCrush.Application.GlobalTypes.Dtos;

public class GlobalTypeProfile : Profile
{
    public GlobalTypeProfile()
    {
        CreateMap<GlobalType, GlobalTypeDto>();

        CreateMap<CreateGlobalTypeCommand, GlobalType>();
        CreateMap<UpdateGlobalTypeCommand, GlobalType>();
    }
}
