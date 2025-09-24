using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Prizes.Commands.Delete;

public class DeletePrizeCommandHandler(ILogger<DeletePrizeCommandHandler> logger,
    IPrizeRepository prizeRepository) : IRequestHandler<DeletePrizeCommand, Result>
{
    public async Task<Result> Handle(DeletePrizeCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting prize with id: {Id}", request.PrizeId);
        var existing = await prizeRepository.FindByIdAsync(request.PrizeId);
        if (existing == null)
        {
            return Result.Failure("Prize not found");
        }

        await prizeRepository.DeleteAsync(existing);
        return Result.Success();
    }
}
