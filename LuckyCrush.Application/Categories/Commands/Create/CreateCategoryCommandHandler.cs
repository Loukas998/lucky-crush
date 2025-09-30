using AutoMapper;
using LuckyCrush.Application.Categories.Dtos;
using LuckyCrush.Domain.Entities.Wheels;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Categories.Commands.Create;

public class CreateCategoryCommandHandler(ILogger<CreateCategoryCommandHandler> logger, IMapper mapper,
    ICategoryRepository categoryRepository) : IRequestHandler<CreateCategoryCommand, Result<CategoryDto>>
{
    public async Task<Result<CategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new category: {@Category}", request);

        var category = mapper.Map<Category>(request);
        var created = await categoryRepository.AddAsync(category);
        var result = mapper.Map<CategoryDto>(created);
        return Result<CategoryDto>.Success(result);
    }
}
