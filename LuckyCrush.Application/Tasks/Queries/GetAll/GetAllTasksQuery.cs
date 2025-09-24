using LuckyCrush.Application.Tasks.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Tasks.Queries.GetAll;

public class GetAllTasksQuery : IRequest<Result<IEnumerable<GoalTaskDto>>>
{
}
