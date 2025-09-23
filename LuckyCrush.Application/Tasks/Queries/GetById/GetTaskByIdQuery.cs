using LuckyCrush.Application.Tasks.Dtos;
using MediatR;

namespace LuckyCrush.Application.Tasks.Queries.GetById;

public class GetTaskByIdQuery : IRequest<GoalTaskDto>
{
    public int TaskId { get; set; }
}
