using LuckyCrush.Application.Unlockables.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Unlockables.Queries.GetAll;

public class GetAllUnlockablesQuery : IRequest<Result<IEnumerable<UnlockableDto>>>
{
}
