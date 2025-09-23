using LuckyCrush.Application.Matches.Dtos;
using MediatR;

namespace LuckyCrush.Application.Matches.Commands.End;

public class EndMatchCommand : IRequest
{
    public int MatchId { get; set; }
    public bool Won { get; set; }
    public int StarsCollected { get; set; }
    public List<DestructionDto> Destructions { get; set; } = [];
}
