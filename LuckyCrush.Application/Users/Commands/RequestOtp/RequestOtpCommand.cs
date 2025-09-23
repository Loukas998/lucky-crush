using MediatR;

namespace LuckyCrush.Application.Users.Commands.RequestOtp;

public class RequestOtpCommand : IRequest
{
    public string PhoneNumber { get; set; } = default!;
}
