using LuckyCrush.Application.Levels.Commands.Create;
using LuckyCrush.Application.Levels.Commands.Delete;
using LuckyCrush.Application.Levels.Commands.Update;
using LuckyCrush.Application.Levels.Dtos;
using LuckyCrush.Application.Levels.Queries.GetAll;
using LuckyCrush.Application.Levels.Queries.GetById;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LuckyCrush.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LevelController(IMediator mediator) : ControllerBase
{
    [HttpPost(nameof(CreateLevel))]
    public async Task<ActionResult<ApiResponse<LevelDto>>> CreateLevel([FromBody] CreateLevelCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse<LevelDto>.Success(
                data: result.Value,
                message: "Level created successfully",
                HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError>()
        {
            new () { Description = result.Error }
        };

        var failureResponse = ApiResponse<LevelDto>.Failure(
            errors,
            "Failed to store level",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiResponse<LevelDto>>> GetLevelById([FromRoute] int id)
    {
        var result = await mediator.Send(new GetLevelByIdQuery(id));
        if (result.IsSuccess)
        {
            var response = ApiResponse<LevelDto>.Success(
                data: result.Value,
                message: "Level created successfully",
                HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError>()
        {
            new () { Description = result.Error }
        };

        var failureResponse = ApiResponse<LevelDto>.Failure(
            errors,
            "Failed to get level",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<LevelDto>>>> GetAllLevels()
    {
        var result = await mediator.Send(new GetAllLevelsQuery());
        if (result.IsSuccess)
        {
            var response = ApiResponse<IEnumerable<LevelDto>>.Success(
                data: result.Value,
                message: "Levels retrieved successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError>()
        {
            new () { Description = result.Error }
        };

        var failureResponse = ApiResponse<LevelDto>.Failure(
            errors,
            "Failed to get levels",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ApiResponse>> DeleteLevel([FromRoute] int id)
    {
        var result = await mediator.Send(new DeleteLevelCommand(id));
        if (result.IsSuccess)
        {
            var response = ApiResponse.Success(
                message: "Levels deleted successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError>()
        {
            new () { Description = result.Error }
        };

        var failureResponse = ApiResponse.Failure(
            errors,
            "Failed to delete levels",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpPatch("{id:int}")]
    public async Task<ActionResult<ApiResponse>> UpdateLevel([FromRoute] int id, [FromBody] UpdateLevelCommand command)
    {
        command.LevelId = id;
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse.Success(
                message: "Levels updated successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError>()
        {
            new () { Description = result.Error }
        };

        var failureResponse = ApiResponse.Failure(
            errors,
            "Failed to updated levels",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }
}
