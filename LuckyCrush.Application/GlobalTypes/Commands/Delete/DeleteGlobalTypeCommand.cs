using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.GlobalTypes.Commands.Delete;

public class DeleteGlobalTypeCommand : IRequest<Result>
{
    public int GlobalTypeId { get; set; }
}
