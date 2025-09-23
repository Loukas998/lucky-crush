using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Users.Commands.VerifyOtp;

public class VerifyOtpCommandHandler(ILogger<VerifyOtpCommandHandler> logger,
    IAccountRepository accountRepository) : IRequestHandler<VerifyOtpCommand, string>
{
    public async Task<string> Handle(VerifyOtpCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Verifying OTP");
        var verifyOtp = await accountRepository.VerifyOtp(request.Code, request.PhoneNumber);

        if (!verifyOtp)
        {

        }

        var sessionToken = await accountRepository.StoreSession(request.PhoneNumber);
        if (sessionToken == null)
        {

        }

        return sessionToken;
    }
}
