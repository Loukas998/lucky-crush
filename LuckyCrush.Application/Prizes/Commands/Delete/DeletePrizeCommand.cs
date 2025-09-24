using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Prizes.Commands.Delete;

public class DeletePrizeCommand : IRequest<Result>
{
    public int PrizeId { get; set; }
}
