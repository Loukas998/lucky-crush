using AutoMapper;
using LuckyCrush.Application.Categories.Commands.Create;
using LuckyCrush.Application.Categories.Commands.Update;
using LuckyCrush.Domain.Entities.Wheels;

namespace LuckyCrush.Application.Categories.Dtos;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDto>()
            .ReverseMap();

        CreateMap<CreateCategoryCommand, Category>();
        CreateMap<UpdateCategoryCommand, Category>();
    }
}
