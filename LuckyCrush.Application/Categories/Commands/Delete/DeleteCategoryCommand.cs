using MediatR;

namespace LuckyCrush.Application.Categories.Commands.Delete;

public class DeleteCategoryCommand : IRequest
{
    public int CategoryId { get; set; }
}
