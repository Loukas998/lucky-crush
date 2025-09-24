using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace LuckyCrush.Application.Rocks.Commands.Update;

public class UpdateRockCommand : IRequest<Result>
{
    public int RockId { get; set; }
    public string Name { get; set; } = default!;
    public IFormFile? Image { get; set; }
}
