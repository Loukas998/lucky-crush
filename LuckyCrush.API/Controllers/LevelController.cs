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
    [HttpPost]
    [Route("CreateLevel")]
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

        var errors = new List<ApiError>() { new() { Description = result.Error } };

        var failureResponse = ApiResponse<LevelDto>.Failure(
            errors,
            "Failed to store level",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpGet]
    [Route("GetLevelById/{id:int}")]
    public async Task<ActionResult<ApiResponse<LevelDto>>> GetLevelById([FromRoute] int id)
    {
        var result = await mediator.Send(new GetLevelByIdQuery(id));
        if (result.IsSuccess)
        {
            var response = ApiResponse<LevelDto>.Success(
                data: result.Value,
                message: "Level retrieved successfully",
                HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError>() { new() { Description = result.Error } };

        var failureResponse = ApiResponse<LevelDto>.Failure(
            errors,
            "Failed to get level",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpGet]
    [Route("GetAllLevels")]
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

        var errors = new List<ApiError>() { new() { Description = result.Error } };

        var failureResponse = ApiResponse<LevelDto>.Failure(
            errors,
            "Failed to get levels",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpDelete]
    [Route("DeleteLevel/{id:int}")]
    public async Task<ActionResult<ApiResponse>> DeleteLevel([FromRoute] int id)
    {
        var result = await mediator.Send(new DeleteLevelCommand(id));
        if (result.IsSuccess)
        {
            var response = ApiResponse.Success(
                message: "Level deleted successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError>() { new() { Description = result.Error } };

        var failureResponse = ApiResponse.Failure(
            errors,
            "Failed to delete level",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpPatch]
    [Route("UpdateLevel/{id:int}")]
    public async Task<ActionResult<ApiResponse>> UpdateLevel([FromRoute] int id, [FromBody] UpdateLevelCommand command)
    {
        command.LevelId = id;
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse.Success(
                message: "Level updated successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError>() { new() { Description = result.Error } };

        var failureResponse = ApiResponse.Failure(
            errors,
            "Failed to update level",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }
}
