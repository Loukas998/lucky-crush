using MediatR;

namespace LuckyCrush.Application.Categories.Commands.Create;

public class CreateCategoryCommand : IRequest<int>
{
    public string Name { get; set; } = default!;
    public bool InGame { get; set; }
}
