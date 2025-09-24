using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Rocks.Commands.Delete;

public class DeleteRockCommand : IRequest<Result>
{
    public int RockId { get; set; }
}
