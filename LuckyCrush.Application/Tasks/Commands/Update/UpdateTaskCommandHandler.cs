using AutoMapper;
using LuckyCrush.Domain.Entities.Tasks;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Tasks.Commands.Update;

public class UpdateTaskCommandHandler(ILogger<UpdateTaskCommandHandler> logger, IMapper mapper,
    ITaskRepository taskRepository) : IRequestHandler<UpdateTaskCommand, Result>
{
    public async Task<Result> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating task with id: {GoalTaskId}, with data: {GoalTask}", request.TaskId, request);
        var existing = await taskRepository.FindByIdAsync(request.TaskId);
        if (existing == null)
        {
            return Result.Failure("Task not found");
        }

        var result = mapper.Map(request, existing);
        existing.Goals.Clear();
        foreach (var goalDto in request.Goals)
        {
            var goal = mapper.Map<Goal>(goalDto);
            existing.Goals.Add(goal);
        }

        await taskRepository.SaveChangesAsync();
        return Result.Success();
    }
}
