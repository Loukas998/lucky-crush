using MediatR;

namespace LuckyCrush.Application.Rocks.Commands.Delete;

public class DeleteRockCommand : IRequest
{
    public int RockId { get; set; }
}
