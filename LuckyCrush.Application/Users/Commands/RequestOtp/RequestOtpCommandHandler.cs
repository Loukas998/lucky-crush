using LuckyCrush.Domain.Entities.Account;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Users.Commands.RequestOtp;

public class RequestOtpCommandHandler(ILogger<RequestOtpCommandHandler> logger,
    IAccountRepository accountRepository) : IRequestHandler<RequestOtpCommand, Result>
{
    public async Task<Result> Handle(RequestOtpCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Registering new user");
        var user = new User
        {
            PhoneNumber = request.PhoneNumber,
            IsSyncedWithFacebook = false
        };

        var registered = await accountRepository.Register(user, "Player");
        if (registered.Any())
        {
            return Result.Failure("Couldn't register");
        }

        logger.LogInformation("Sending OTP");

        var otp = new Otp
        {
            Code = new Random().Next(100000, 999999).ToString(),
            ExpiresAt = DateTime.UtcNow.AddMinutes(5),
            IsUsed = false,
            UserId = user.Id
        };
        var otpRegistered = await accountRepository.StoreOtp(otp);
        return Result.Success();
    }
}
