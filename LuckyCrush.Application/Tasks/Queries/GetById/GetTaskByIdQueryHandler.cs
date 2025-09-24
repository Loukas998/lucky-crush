using AutoMapper;
using LuckyCrush.Application.Tasks.Dtos;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Tasks.Queries.GetById;

public class GetTaskByIdQueryHandler(ILogger<GetTaskByIdQueryHandler> logger, IMapper mapper,
    ITaskRepository taskRepository) : IRequestHandler<GetTaskByIdQuery, Result<GoalTaskDto>>
{
    public async Task<Result<GoalTaskDto>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting task with Id: {TaskId}", request.TaskId);

        var task = await taskRepository.GetTaskWithGoals(request.TaskId);
        if (task == null)
        {
            return Result<GoalTaskDto>.Failure("Task not found");
        }

        var result = mapper.Map<GoalTaskDto>(task);
        return Result<GoalTaskDto>.Success(result);
    }
}
