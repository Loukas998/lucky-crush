using MediatR;

namespace LuckyCrush.Application.GlobalTypes.Commands.Update;

public class UpdateGlobalTypeCommand : IRequest
{
    public int GlobalTypeId { get; set; }
    public string TypeName { get; set; } = default!;
    public string Name { get; set; } = default!;
}
