using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Categories.Commands.Delete;

public class DeleteCategoryCommandHandler(ILogger<DeleteCategoryCommandHandler> logger,
    ICategoryRepository categoryRepository) : IRequestHandler<DeleteCategoryCommand, Result>
{
    public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting category with id: {Id}", request.CategoryId);
        var existing = await categoryRepository.FindByIdAsync(request.CategoryId);
        if (existing == null)
        {
            return Result.Failure("Category not found");
        }

        await categoryRepository.DeleteAsync(existing);
        return Result.Success();
    }
}
