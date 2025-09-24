using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Rewards.Commands.Create;

public class CreateRewardCommand : IRequest<Result<int>>
{
    public int TypeId { get; set; }
    public int TaskId { get; set; }
    public int Amount { get; set; }
}
