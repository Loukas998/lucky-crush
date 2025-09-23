using AutoMapper;
using LuckyCrush.Domain.Entities.Tasks;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Tasks.Commands.Create;

public class CreateTaskCommandHandler(ILogger<CreateTaskCommandHandler> logger, IMapper mapper,
    ITaskRepository taskRepository) : IRequestHandler<CreateTaskCommand, int>
{
    public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new task: {@Task}", request);
        var task = mapper.Map<GoalTask>(request);

        await taskRepository.AddAsync(task);
        return task.Id;
    }
}
