using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Users.Commands.VerifyOtp;

public class VerifyOtpCommandHandler(ILogger<VerifyOtpCommandHandler> logger,
    IAccountRepository accountRepository) : IRequestHandler<VerifyOtpCommand, Result<string>>
{
    public async Task<Result<string>> Handle(VerifyOtpCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Verifying OTP");
        var verifyOtp = await accountRepository.VerifyOtp(request.Code, request.PhoneNumber);

        if (!verifyOtp)
        {
            return Result<string>.Failure("Couldn't verify OTP");
        }

        var sessionToken = await accountRepository.StoreSession(request.PhoneNumber);
        if (sessionToken == null)
        {
            return Result<string>.Failure("Session token not found");
        }

        return Result<string>.Success(sessionToken);
    }
}
