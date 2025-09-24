using AutoMapper;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Categories.Commands.Update;

public class UpdateCategoryCommandHandler(ILogger<UpdateCategoryCommandHandler> logger, IMapper mapper,
    ICategoryRepository categoryRepository) : IRequestHandler<UpdateCategoryCommand, Result>
{
    public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating category of id:{Id} with {@Category}", request.CategoryId, request);
        var existing = await categoryRepository.FindByIdAsync(request.CategoryId);
        if (existing == null)
        {
            return Result.Failure("Category not found");
        }

        mapper.Map(request, existing);
        await categoryRepository.SaveChangesAsync();
        return Result.Success();
    }
}
