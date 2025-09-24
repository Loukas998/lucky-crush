using AutoMapper;
using LuckyCrush.Application.Categories.Dtos;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Categories.Queries.GetAll;

public class GetAllCategoriesQueryHandler(ILogger<GetAllCategoriesQueryHandler> logger, IMapper mapper,
    ICategoryRepository categoryRepository) : IRequestHandler<GetAllCategoriesQuery, Result<IEnumerable<CategoryDto>>>
{
    public async Task<Result<IEnumerable<CategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all categories");
        var categories = await categoryRepository.GetAllAsync();
        var results = mapper.Map<IEnumerable<CategoryDto>>(categories);
        return Result<IEnumerable<CategoryDto>>.Success(results);
    }
}
