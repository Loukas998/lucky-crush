using LuckyCrush.Application.Matches.Dtos;
using LuckyCrush.Application.Users.Commands.CreateAccount;
using LuckyCrush.Application.Users.Commands.Login;
using LuckyCrush.Application.Users.Commands.RefreshToken;
using LuckyCrush.Application.Users.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LuckyCrush.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost(nameof(Register))]
    public async Task<ActionResult<ApiResponse<IEnumerable<IdentityError>>>> Register([FromBody] CreateAccountCommand command)
    {
        var result = await mediator.Send(command);
        var response = ApiResponse<IEnumerable<IdentityError>>.Success(
                result.Value,
                "Account registered",
                HttpStatusCode.OK
            );
        if (result.Value.Any())
        {
            return Ok(response);
        }
        return BadRequest(response);
    }

    [HttpPost(nameof(Login))]
    public async Task<ActionResult<ApiResponse<Result<LoginResponse>>>> Login([FromBody] LoginCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse<LoginResponse>.Success(result.Value, "Login succeed", HttpStatusCode.OK);
            return Ok(response);
        }

        var errors = new List<ApiError>()
        {
            new () { Description = result.Error }
        };

        var failureResponse = ApiResponse<MatchDto>.Failure(
            errors,
            "Failed to login",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpPost(nameof(RefreshToken))]
    public async Task<ActionResult<ApiResponse<Result<LoginResponse>>>> RefreshToken([FromBody] RefreshTokenCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse<LoginResponse>.Success(result.Value, "Token refreshed successfully", HttpStatusCode.OK);
            return Ok(response);
        }

        var errors = new List<ApiError>()
        {
            new () { Description = result.Error }
        };

        var failureResponse = ApiResponse<MatchDto>.Failure(
            errors,
            "Failed to refresh token",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }
}
//[HttpPost(nameof(Register))]
//public async Task<ActionResult<ApiResponse>> Register([FromBody] RequestOtpCommand command)
//{
//    var result = await mediator.Send(command);
//    if (result.IsSuccess)
//    {
//        var response = ApiResponse.Success("Account registered", HttpStatusCode.OK);
//        return Ok(response);
//    }

//    var errors = new List<ApiError>()
//    {
//        new () { Description = result.Error }
//    };

//    var failureResponse = ApiResponse<MatchDto>.Failure(
//        errors,
//        "Failed to register",
//        HttpStatusCode.BadRequest
//    );

//    return BadRequest(failureResponse);
//}

//[HttpPost(nameof(VerifyOtp))]
//    public async Task<ActionResult<ApiResponse>> VerifyOtp([FromBody] VerifyOtpCommand command)
//    {
//        var result = await mediator.Send(command);
//        if (result.IsSuccess)
//        {
//            var response = ApiResponse<string>.Success(result.Value, "OTP verified", HttpStatusCode.OK);
//            return Ok(response);
//        }

//        var errors = new List<ApiError>()
//        {
//            new () { Description = result.Error }
//        };

//        var failureResponse = ApiResponse<MatchDto>.Failure(
//            errors,
//            "Failed to verify",
//            HttpStatusCode.BadRequest
//        );

//        return BadRequest(failureResponse);
//    }