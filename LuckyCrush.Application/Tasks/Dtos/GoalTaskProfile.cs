using AutoMapper;
using LuckyCrush.Application.Tasks.Commands.Create;
using LuckyCrush.Application.Tasks.Commands.Update;
using LuckyCrush.Domain.Entities.Tasks;

namespace LuckyCrush.Application.Tasks.Dtos;

public class GoalTaskProfile : Profile
{
    public GoalTaskProfile()
    {
        CreateMap<GoalTask, GoalTaskDto>()
            .ReverseMap();

        CreateMap<CreateTaskCommand, GoalTask>();
        CreateMap<UpdateTaskCommand, GoalTask>();
    }
}
