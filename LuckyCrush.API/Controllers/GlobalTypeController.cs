using LuckyCrush.Application.GlobalTypes.Commands.Create;
using LuckyCrush.Application.GlobalTypes.Commands.Delete;
using LuckyCrush.Application.GlobalTypes.Commands.Update;
using LuckyCrush.Application.GlobalTypes.Dtos;
using LuckyCrush.Application.GlobalTypes.Queries.GetAll;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LuckyCrush.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GlobalTypeController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<ApiResponse<GlobalTypeDto>>> CreateGlobalType([FromForm] CreateGlobalTypeCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse<GlobalTypeDto>.Success(
                data: result.Value,
                message: "GlobalType created successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse<GlobalTypeDto>.Failure(
            errors,
            "Failed to create global type",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<GlobalTypeDto>>>> GetAllGlobalTypes()
    {
        var result = await mediator.Send(new GetAllGlobalQuery());
        if (result.IsSuccess)
        {
            var response = ApiResponse<IEnumerable<GlobalTypeDto>>.Success(
                data: result.Value,
                message: "GlobalTypes fetched successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse<IEnumerable<GlobalTypeDto>>.Failure(
            errors,
            "Failed to fetch global types",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpPatch("{id:int}")]
    public async Task<ActionResult<ApiResponse>> UpdateGlobalType([FromRoute] int id, [FromForm] UpdateGlobalTypeCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse.Success(
                message: "GlobalType updated successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse.Failure(
            errors,
            "Failed to update global type",
            HttpStatusCode.BadRequest
        );

        return NotFound(failureResponse);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ApiResponse>> DeleteGlobalType([FromRoute] int id)
    {
        var result = await mediator.Send(new DeleteGlobalTypeCommand(id));
        if (result.IsSuccess)
        {
            var response = ApiResponse.Success(
                message: "GlobalType deleted successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse.Failure(
            errors,
            "Failed to delete global type",
            HttpStatusCode.BadRequest
        );

        return NotFound(failureResponse);
    }
}
