using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace LuckyCrush.Application.Unlockables.Commands.Create;

public class CreateUnlockableCommand : IRequest<Result<int>>
{
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!; // Style or Achievement 
    public IFormFile? Image { get; set; }
}
