using LuckyCrush.Application.Tasks.Dtos;
using MediatR;

namespace LuckyCrush.Application.Tasks.Queries.GetAll;

public class GetAllTasksQuery : IRequest<IEnumerable<GoalTaskDto>>
{
}
