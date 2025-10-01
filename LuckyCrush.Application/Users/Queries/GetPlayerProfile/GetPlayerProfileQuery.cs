using LuckyCrush.Application.Users.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Users.Queries.GetPlayerProfile;

public class GetPlayerProfileQuery : IRequest<Result<ProfileDto>>
{
}
