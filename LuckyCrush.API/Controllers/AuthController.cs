using LuckyCrush.Application.Matches.Dtos;
using LuckyCrush.Application.Users.Commands.RequestOtp;
using LuckyCrush.Application.Users.Commands.VerifyOtp;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LuckyCrush.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost(nameof(Register))]
    public async Task<ActionResult<ApiResponse>> Register([FromBody] RequestOtpCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse.Success("Account registered", HttpStatusCode.OK);
            return Ok(response);
        }

        var errors = new List<ApiError>()
        {
            new () { Description = result.Error }
        };

        var failureResponse = ApiResponse<MatchDto>.Failure(
            errors,
            "Failed to register",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpPost(nameof(VerifyOtp))]
    public async Task<ActionResult<ApiResponse>> VerifyOtp([FromBody] VerifyOtpCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse<string>.Success(result.Value, "OTP verified", HttpStatusCode.OK);
            return Ok(response);
        }

        var errors = new List<ApiError>()
        {
            new () { Description = result.Error }
        };

        var failureResponse = ApiResponse<MatchDto>.Failure(
            errors,
            "Failed to verify",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }
}
