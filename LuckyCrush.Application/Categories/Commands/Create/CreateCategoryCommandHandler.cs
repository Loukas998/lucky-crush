using AutoMapper;
using LuckyCrush.Domain.Entities.Wheels;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Categories.Commands.Create;

public class CreateCategoryCommandHandler(ILogger<CreateCategoryCommandHandler> logger, IMapper mapper,
    ICategoryRepository categoryRepository) : IRequestHandler<CreateCategoryCommand, int>
{
    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new category: {@Category}", request);
        var category = mapper.Map<Category>(request);
        var created = await categoryRepository.AddAsync(category);
        return created.Id;
    }
}
