using LuckyCrush.Application.Matches.Dtos;
using LuckyCrush.Application.Rocks.Commands.Create;
using LuckyCrush.Application.Rocks.Commands.Delete;
using LuckyCrush.Application.Rocks.Commands.Update;
using LuckyCrush.Application.Rocks.Dtos;
using LuckyCrush.Application.Rocks.Queries.GetAll;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LuckyCrush.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RockController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Route("CreateRock")]
    public async Task<ActionResult<ApiResponse<RockDto>>> CreateRock([FromForm] CreateRockCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse<RockDto>.Success(
                data: result.Value,
                message: "Rock created successfully",
                statusCode: System.Net.HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError>()
        {
            new () { Description = result.Error }
        };

        var failureResponse = ApiResponse<MatchDto>.Failure(
            errors,
            "Failed to store rock",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpGet]
    [Route("GetAllRocks")]
    public async Task<ActionResult<ApiResponse<IEnumerable<RockDto>>>> GetAllRocks()
    {
        var result = await mediator.Send(new GetAllRocksQuery());
        if (result.IsSuccess)
        {
            var response = ApiResponse<IEnumerable<RockDto>>.Success(
                data: result.Value,
                message: "Rock created successfully",
                statusCode: System.Net.HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError>()
        {
            new () { Description = result.Error }
        };

        var failureResponse = ApiResponse<IEnumerable<RockDto>>.Failure(
            errors,
            "Failed to store rock",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpPatch]
    [Route("UpdateRock/{id}")]
    public async Task<ActionResult<ApiResponse>> UpdateRock([FromRoute] int id, [FromForm] UpdateRockCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse.Success(
                message: "Rock updated successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError>() { new() { Description = result.Error } };

        var failureResponse = ApiResponse.Failure(
            errors,
            "Failed to update rock",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpDelete]
    [Route("DeleteRock/{id:int}")]
    public async Task<ActionResult<ApiResponse>> DeleteRock([FromRoute] int id)
    {
        var result = await mediator.Send(new DeleteRockCommand(id));
        if (result.IsSuccess)
        {
            var response = ApiResponse.Success(
                message: "Rock deleted successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError>() { new() { Description = result.Error } };

        var failureResponse = ApiResponse.Failure(
            errors,
            "Failed to delete rock",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }
}
