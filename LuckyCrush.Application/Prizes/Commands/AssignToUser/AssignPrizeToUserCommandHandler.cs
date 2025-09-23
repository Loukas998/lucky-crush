using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Prizes.Commands.AssignToUser;

public class AssignPrizeToUserCommandHandler(ILogger<AssignPrizeToUserCommandHandler> logger,
    IPrizeRepository prizeRepository, IAccountRepository accountRepository) : IRequestHandler<AssignPrizeToUserCommand>
{
    public async Task Handle(AssignPrizeToUserCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Assigning prize to user");

        var user = await accountRepository.GetUserByIdAsync(request.UserId);
        if (user == null)
        {

        }

        var prize = await prizeRepository.FindByIdAsync(request.PrizeId);
        if (prize == null)
        {

        }

        user.Prizes.Add(prize);
    }
}
