using MediatR;

namespace LuckyCrush.Application.Rewards.Commands.Create;

public class CreateRewardCommand : IRequest<int>
{
    public int TypeId { get; set; }
    public int TaskId { get; set; }
    public int Amount { get; set; }
}
