using MediatR;

namespace LuckyCrush.Application.GlobalTypes.Commands.Create;

public class CreateGlobalTypeCommand : IRequest<int>
{
    public string TypeName { get; set; } = default!;
    public string Name { get; set; } = default!;
}
