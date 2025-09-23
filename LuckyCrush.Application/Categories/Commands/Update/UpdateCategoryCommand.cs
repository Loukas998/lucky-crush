using MediatR;

namespace LuckyCrush.Application.Categories.Commands.Update;

public class UpdateCategoryCommand : IRequest
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = default!;
    public bool InGame { get; set; }
}
