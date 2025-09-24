using LuckyCrush.Application.Matches.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Matches.Commands.End;

public class EndMatchCommand : IRequest<Result>
{
    public int MatchId { get; set; }
    public bool Won { get; set; }
    public int StarsCollected { get; set; }
    public List<DestructionDto> Destructions { get; set; } = [];
}
