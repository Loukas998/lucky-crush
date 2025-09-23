using LuckyCrush.Application.Unlockables.Dtos;
using MediatR;

namespace LuckyCrush.Application.Unlockables.Queries.GetAll;

public class GetAllUnlockablesQuery : IRequest<IEnumerable<UnlockableDto>>
{
}
