using AutoMapper;
using LuckyCrush.Domain.Entities.Tasks;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Tasks.Commands.Create;

public class CreateTaskCommandHandler(ILogger<CreateTaskCommandHandler> logger, IMapper mapper,
    ITaskRepository taskRepository) : IRequestHandler<CreateTaskCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new task: {@Task}", request);
        var task = mapper.Map<GoalTask>(request);

        await taskRepository.AddAsync(task);
        return Result<int>.Success(task.Id);
    }
}
