using AutoMapper;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Tasks.Commands.Delete;

public class DeleteTaskCommandHandler(ILogger<DeleteTaskCommandHandler> logger, IMapper mapper,
    ITaskRepository taskRepository) : IRequestHandler<DeleteTaskCommand, Result>
{
    public async Task<Result> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting task with Id: {TaskId}", request.TaskId);
        var existing = await taskRepository.FindByIdAsync(request.TaskId);
        if (existing == null)
        {
            return Result.Failure("Task not found");
        }

        var result = mapper.Map(request, existing);
        existing.Goals.Clear();
        await taskRepository.DeleteAsync(existing);
        return Result.Success();
    }
}
