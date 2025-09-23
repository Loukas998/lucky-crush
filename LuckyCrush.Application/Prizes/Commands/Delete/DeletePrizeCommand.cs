using MediatR;

namespace LuckyCrush.Application.Prizes.Commands.Delete;

public class DeletePrizeCommand : IRequest
{
    public int PrizeId { get; set; }
}
