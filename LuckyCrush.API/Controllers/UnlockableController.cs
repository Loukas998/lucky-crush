using LuckyCrush.Application.Unlockables.Commands.Create;
using LuckyCrush.Application.Unlockables.Commands.Delete;
using LuckyCrush.Application.Unlockables.Commands.Update;
using LuckyCrush.Application.Unlockables.Dtos;
using LuckyCrush.Application.Unlockables.Queries.GetAll;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LuckyCrush.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UnlockableController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<ApiResponse<UnlockableDto>>> CreateUnlockable([FromForm] CreateUnlockableCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse<UnlockableDto>.Success(
                data: result.Value,
                message: "Unlockable created successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse<UnlockableDto>.Failure(
            errors,
            "Failed to create unlockable",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<UnlockableDto>>>> GetAllUnlockables()
    {
        var result = await mediator.Send(new GetAllUnlockablesQuery());
        if (result.IsSuccess)
        {
            var response = ApiResponse<IEnumerable<UnlockableDto>>.Success(
                data: result.Value,
                message: "Unlockables fetched successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse<IEnumerable<UnlockableDto>>.Failure(
            errors,
            "Failed to fetch unlockables",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ApiResponse>> UpdateUnlockable([FromRoute] int id, [FromForm] UpdateUnlockableCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse.Success(
                message: "Unlockable updated successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse.Failure(
            errors,
            "Failed to update unlockable",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ApiResponse>> DeleteUnlockable([FromRoute] int id)
    {
        var result = await mediator.Send(new DeleteUnlockableCommand(id));
        if (result.IsSuccess)
        {
            var response = ApiResponse.Success(
                message: "Unlockable deleted successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse.Failure(
            errors,
            "Failed to delete unlockable",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }
}