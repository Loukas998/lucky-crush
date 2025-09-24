using LuckyCrush.Application.GlobalTypes.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.GlobalTypes.Queries.GetAll;

public class GetAllGlobalQuery : IRequest<Result<IEnumerable<GlobalTypeDto>>>
{
}
