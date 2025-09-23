using MediatR;

namespace LuckyCrush.Application.GlobalTypes.Commands.Delete;

public class DeleteGlobalTypeCommand : IRequest
{
    public int GlobalTypeId { get; set; }
}
