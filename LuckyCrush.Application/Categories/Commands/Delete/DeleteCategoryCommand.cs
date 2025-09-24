using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Categories.Commands.Delete;

public class DeleteCategoryCommand : IRequest<Result>
{
    public int CategoryId { get; set; }
}
