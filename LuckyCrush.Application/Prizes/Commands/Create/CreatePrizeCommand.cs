using LuckyCrush.Application.Prizes.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace LuckyCrush.Application.Prizes.Commands.Create;

public class CreatePrizeCommand : IRequest<Result<PrizeDto>>
{
    public int WheelId { get; set; }
    public int CategoryId { get; set; }
    public int Amount { get; set; }
    public IFormFile? Image { get; set; }
}
