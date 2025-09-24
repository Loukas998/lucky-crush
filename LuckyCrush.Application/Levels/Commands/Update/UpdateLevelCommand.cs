using LuckyCrush.Application.Levels.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Levels.Commands.Update;

public class UpdateLevelCommand : IRequest<Result>
{
    public int LevelId { get; set; }
    public int Number { get; set; }
    public bool IsSpecial { get; set; }
    public int RequiredStars { get; set; }
    public List<RequirementDto> Requirements { get; set; } = [];
}
