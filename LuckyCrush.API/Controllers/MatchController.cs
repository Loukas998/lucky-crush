using LuckyCrush.Application.Matches.Commands.End;
using LuckyCrush.Application.Matches.Commands.Start;
using LuckyCrush.Application.Matches.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LuckyCrush.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatchController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Route("StartMatch")]
    public async Task<ActionResult<ApiResponse<MatchDto>>> StartMatch([FromBody] StartMatchCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse<MatchDto>.Success(
                data: result.Value,
                message: "Match started recording successfully",
                HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse<MatchDto>.Failure(
            errors,
            "Failed to store match",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpPost]
    [Route("EndMatch")]
    public async Task<ActionResult<ApiResponse>> EndMatch([FromBody] EndMatchCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse.Success(
                message: "Match ended recording successfully",
                HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse<MatchDto>.Failure(
            errors,
            "Failed to store match",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }
}
