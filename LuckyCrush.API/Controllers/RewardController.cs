using LuckyCrush.Application.Rewards.Commands.Create;
using LuckyCrush.Application.Rewards.Commands.Delete;
using LuckyCrush.Application.Rewards.Commands.Update;
using LuckyCrush.Application.Rewards.Dtos;
using LuckyCrush.Application.Rewards.Queries.GetAll;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LuckyCrush.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RewardController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<ApiResponse<RewardDto>>> CreateReward([FromForm] CreateRewardCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse<RewardDto>.Success(
                data: result.Value,
                message: "Reward created successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse<RewardDto>.Failure(
            errors,
            "Failed to create reward",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<RewardDto>>>> GetAllRewards()
    {
        var result = await mediator.Send(new GetAllRewardsQuery());
        if (result.IsSuccess)
        {
            var response = ApiResponse<IEnumerable<RewardDto>>.Success(
                data: result.Value,
                message: "Rewards fetched successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse<IEnumerable<RewardDto>>.Failure(
            errors,
            "Failed to fetch rewards",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpPatch("{id:int}")]
    public async Task<ActionResult<ApiResponse>> UpdateReward([FromRoute] int id, [FromForm] UpdateRewardCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse.Success(
                message: "Reward updated successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse.Failure(
            errors,
            "Failed to update reward",
            HttpStatusCode.BadRequest
        );

        return NotFound(failureResponse);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ApiResponse>> DeleteReward([FromRoute] int id)
    {
        var result = await mediator.Send(new DeleteRewardCommand(id));
        if (result.IsSuccess)
        {
            var response = ApiResponse.Success(
                message: "Reward deleted successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse.Failure(
            errors,
            "Failed to delete reward",
            HttpStatusCode.BadRequest
        );

        return NotFound(failureResponse);
    }
}