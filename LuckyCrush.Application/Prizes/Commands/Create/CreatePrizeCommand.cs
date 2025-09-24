using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace LuckyCrush.Application.Prizes.Commands.Create;

public class CreatePrizeCommand : IRequest<Result<int>>
{
    public int WheelId { get; set; }
    public int CategoryId { get; set; }
    public int Amount { get; set; }
    public IFormFile? Image { get; set; }
}
