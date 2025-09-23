using AutoMapper;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Tasks.Commands.Delete;

public class DeleteTaskCommandHandler(ILogger<DeleteTaskCommandHandler> logger, IMapper mapper,
    ITaskRepository taskRepository) : IRequestHandler<DeleteTaskCommand>
{
    public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting task with Id: {TaskId}", request.TaskId);
        var existing = await taskRepository.FindByIdAsync(request.TaskId);
        if (existing == null)
        {

        }

        var result = mapper.Map(request, existing);
        existing.Goals.Clear();
        await taskRepository.DeleteAsync(existing);
    }
}
