using AutoMapper;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Categories.Commands.Delete;

public class DeleteCategoryCommandHandler(ILogger<DeleteCategoryCommandHandler> logger, IMapper mapper,
    ICategoryRepository categoryRepository) : IRequestHandler<DeleteCategoryCommand>
{
    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting category with id: {Id}", request.CategoryId);
        var existing = await categoryRepository.FindByIdAsync(request.CategoryId);
        if (existing == null)
        {

        }

        await categoryRepository.DeleteAsync(existing);
    }
}
