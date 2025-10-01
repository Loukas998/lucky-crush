using LuckyCrush.Application.Prizes.Dtos;
using LuckyCrush.Application.Users.Dtos;
using LuckyCrush.Application.Users.Queries.GetPlayerBalance;
using LuckyCrush.Application.Users.Queries.GetPlayerPrizes;
using LuckyCrush.Application.Users.Queries.GetPlayerProfile;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LuckyCrush.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpGet(nameof(GetPlayerProfile))]
    public async Task<ActionResult<ApiResponse<ProfileDto>>> GetPlayerProfile()
    {
        var result = await mediator.Send(new GetPlayerProfileQuery());
        var response = ApiResponse<ProfileDto>.Success(result.Value, "Profile retrieved successfully", HttpStatusCode.OK);
        return Ok(response);
    }

    [Authorize]
    [HttpGet(nameof(GetPlayerBalance))]
    public async Task<ActionResult<ApiResponse<BalanceDto>>> GetPlayerBalance()
    {
        var result = await mediator.Send(new GetPlayerBalanceQuery());
        var response = ApiResponse<BalanceDto>.Success(result.Value, "Balance retrieved successfully", HttpStatusCode.OK);
        return Ok(response);
    }

    [Authorize]
    [HttpGet(nameof(GetPlayerPrizes))]
    public async Task<ActionResult<ApiResponse<IEnumerable<PrizeDto>>>> GetPlayerPrizes()
    {
        var result = await mediator.Send(new GetPlayerPrizesQuery());
        var response = ApiResponse<IEnumerable<PrizeDto>>.Success(result.Value, "Prizes retrieved successfully", HttpStatusCode.OK);
        return Ok(response);
    }
}
