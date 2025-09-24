using LuckyCrush.Application.Categories.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Categories.Queries.GetAll;

public class GetAllCategoriesQuery : IRequest<Result<IEnumerable<CategoryDto>>>
{
}
