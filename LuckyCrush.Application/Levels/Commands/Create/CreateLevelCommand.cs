using LuckyCrush.Application.Levels.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Levels.Commands.Create;

public class CreateLevelCommand : IRequest<Result<int>>
{
    public int Number { get; set; }
    public bool IsSpecial { get; set; }
    public int RequiredStars { get; set; }
    public List<RequirementDto> Requirements { get; set; } = [];
}
