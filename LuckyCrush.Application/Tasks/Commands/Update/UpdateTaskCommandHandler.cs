using AutoMapper;
using LuckyCrush.Domain.Entities.Tasks;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Tasks.Commands.Update;

public class UpdateTaskCommandHandler(ILogger<UpdateTaskCommandHandler> logger, IMapper mapper,
    ITaskRepository taskRepository) : IRequestHandler<UpdateTaskCommand>
{
    public async Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating task with id: {GoalTaskId}, with data: {GoalTask}", request.TaskId, request);
        var existing = await taskRepository.FindByIdAsync(request.TaskId);
        if (existing == null)
        {

        }

        var result = mapper.Map(request, existing);
        existing.Goals.Clear();
        foreach (var goalDto in request.Goals)
        {
            var goal = mapper.Map<Goal>(goalDto);
            existing.Goals.Add(goal);
        }

        await taskRepository.SaveChangesAsync();
    }
}
