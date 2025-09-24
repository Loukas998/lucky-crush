using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Prizes.Commands.AssignToUser;

public class AssignPrizeToUserCommandHandler(ILogger<AssignPrizeToUserCommandHandler> logger,
    IPrizeRepository prizeRepository, IAccountRepository accountRepository) : IRequestHandler<AssignPrizeToUserCommand, Result>
{
    public async Task<Result> Handle(AssignPrizeToUserCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Assigning prize to user");

        var user = await accountRepository.GetUserByIdAsync(request.UserId);
        if (user == null)
        {
            return Result.Failure("User not found");
        }

        var prize = await prizeRepository.FindByIdAsync(request.PrizeId);
        if (prize == null)
        {
            return Result.Failure("Prize not found");
        }

        user.Prizes.Add(prize);
        return Result.Success();
    }
}
