using MediatR;

namespace LuckyCrush.Application.Matches.Commands.Start;

public class StartMatchCommand : IRequest<int>
{
    public string UserId { get; set; } = default!;
    public int LevelId { get; set; }
}
