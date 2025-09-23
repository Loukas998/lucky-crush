using LuckyCrush.Application.GlobalTypes.Dtos;
using MediatR;

namespace LuckyCrush.Application.GlobalTypes.Queries.GetAll;

public class GetAllGlobalQuery : IRequest<IEnumerable<GlobalTypeDto>>
{
}
