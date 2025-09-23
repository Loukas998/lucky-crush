using MediatR;
using Microsoft.AspNetCore.Http;

namespace LuckyCrush.Application.Prizes.Commands.Update;

public class UpdatePrizeCommand : IRequest
{
    public int PrizeId { get; set; }
    public int WheelId { get; set; }
    public int CategoryId { get; set; }
    public int Amount { get; set; }
    public IFormFile? Image { get; set; }
}
