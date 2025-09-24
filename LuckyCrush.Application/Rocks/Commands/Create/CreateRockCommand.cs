using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace LuckyCrush.Application.Rocks.Commands.Create;

public class CreateRockCommand : IRequest<Result<int>>
{
    public string Name { get; set; } = default!;
    public IFormFile? Image { get; set; }
}
