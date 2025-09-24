using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace LuckyCrush.Application.Unlockables.Commands.Update;

public class UpdateUnlockableCommand : IRequest<Result>
{
    public int UnlockableId { get; set; }
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!; // Style or Achievement 
    public IFormFile? Image { get; set; }
}
