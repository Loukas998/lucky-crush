using LuckyCrush.Domain.Entities.Account;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Users.Commands.RequestOtp;

public class RequestOtpCommandHandler(ILogger<RequestOtpCommandHandler> logger,
    IAccountRepository accountRepository) : IRequestHandler<RequestOtpCommand>
{
    public async Task Handle(RequestOtpCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            PhoneNumber = request.PhoneNumber,
            IsSyncedWithFacebook = false
        };

        var registered = await accountRepository.Register(user, "Player");
        if (registered.Any())
        {

        }

        var otp = new Otp
        {
            Code = new Random().Next(100000, 999999).ToString(),
            ExpiresAt = DateTime.UtcNow.AddMinutes(5),
            IsUsed = false,
            UserId = user.Id
        };
        var otpRegistered = await accountRepository.StoreOtp(otp);
    }
}
