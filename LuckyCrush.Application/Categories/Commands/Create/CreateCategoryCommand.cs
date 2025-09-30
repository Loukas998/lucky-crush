using LuckyCrush.Application.Categories.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Categories.Commands.Create;

public class CreateCategoryCommand : IRequest<Result<CategoryDto>>
{
    public string Name { get; set; } = default!;
    public bool InGame { get; set; }
}
