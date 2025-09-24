using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Prizes.Commands.AssignToUser;

public class AssignPrizeToUserCommand : IRequest<Result>
{
    public string UserId { get; set; } = string.Empty;
    public int PrizeId { get; set; }
}
