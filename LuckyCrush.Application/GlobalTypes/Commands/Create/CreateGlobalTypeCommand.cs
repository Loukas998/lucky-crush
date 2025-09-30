using LuckyCrush.Application.GlobalTypes.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.GlobalTypes.Commands.Create;

public class CreateGlobalTypeCommand : IRequest<Result<GlobalTypeDto>>
{
    public string TypeName { get; set; } = default!;
    public string Name { get; set; } = default!;
}
