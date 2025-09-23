using AutoMapper;
using LuckyCrush.Application.Tasks.Dtos;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Tasks.Queries.GetAll;

public class GetAllTasksQueryHandler(ILogger<GetAllTasksQueryHandler> logger, IMapper mapper,
    ITaskRepository taskRepository) : IRequestHandler<GetAllTasksQuery, IEnumerable<GoalTaskDto>>
{
    public async Task<IEnumerable<GoalTaskDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all tasks");
        var tasks = await taskRepository.GetAllAsync();

        var results = mapper.Map<IEnumerable<GoalTaskDto>>(tasks);
        return results;
    }
}
