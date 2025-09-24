using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Categories.Commands.Create;

public class CreateCategoryCommand : IRequest<Result<int>>
{
    public string Name { get; set; } = default!;
    public bool InGame { get; set; }
}
