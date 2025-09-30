using AutoMapper;
using LuckyCrush.Application.Tasks.Dtos;
using LuckyCrush.Domain.Entities.Tasks;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Tasks.Commands.Create;

public class CreateTaskCommandHandler(ILogger<CreateTaskCommandHandler> logger, IMapper mapper,
    ITaskRepository taskRepository) : IRequestHandler<CreateTaskCommand, Result<GoalTaskDto>>
{
    public async Task<Result<GoalTaskDto>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new task: {@Task}", request);
        var task = mapper.Map<GoalTask>(request);
        var created = await taskRepository.AddAsync(task);
        var result = mapper.Map<GoalTaskDto>(created);
        return Result<GoalTaskDto>.Success(result);
    }
}
