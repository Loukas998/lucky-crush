using LuckyCrush.Application.Matches.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Matches.Commands.Start;

public class StartMatchCommand : IRequest<Result<MatchDto>>
{
    public string UserId { get; set; } = default!;
    public int LevelId { get; set; }
}
