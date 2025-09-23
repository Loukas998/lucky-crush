using LuckyCrush.Application.Categories.Dtos;
using MediatR;

namespace LuckyCrush.Application.Categories.Queries.GetAll;

public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
{
}
