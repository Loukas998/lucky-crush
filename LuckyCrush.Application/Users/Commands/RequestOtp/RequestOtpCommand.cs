using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Users.Commands.RequestOtp;

public class RequestOtpCommand : IRequest<Result>
{
    public string PhoneNumber { get; set; } = default!;
}
