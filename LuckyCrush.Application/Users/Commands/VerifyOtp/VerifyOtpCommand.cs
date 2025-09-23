using MediatR;

namespace LuckyCrush.Application.Users.Commands.VerifyOtp;

public class VerifyOtpCommand : IRequest<string>
{
    public string PhoneNumber { get; set; } = default!;
    public string Code { get; set; } = default!;
}
