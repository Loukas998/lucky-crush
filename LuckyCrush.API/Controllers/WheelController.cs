using LuckyCrush.Application.Wheels.Commands.Create;
using LuckyCrush.Application.Wheels.Commands.Delete;
using LuckyCrush.Application.Wheels.Commands.Update;
using LuckyCrush.Application.Wheels.Dtos;
using LuckyCrush.Application.Wheels.Queries.GetAll;
using LuckyCrush.Application.Wheels.Queries.GetById;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LuckyCrush.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WheelController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Route("CreateWheel")]
    public async Task<ActionResult<ApiResponse<WheelDto>>> CreateWheel([FromForm] CreateWheelCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse<WheelDto>.Success(
                data: result.Value,
                message: "Wheel created successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse<WheelDto>.Failure(
            errors,
            "Failed to create wheel",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpGet]
    [Route("GetAllWheels")]
    public async Task<ActionResult<ApiResponse<IEnumerable<WheelDto>>>> GetAllWheels()
    {
        var result = await mediator.Send(new GetAllWheelsQuery());
        if (result.IsSuccess)
        {
            var response = ApiResponse<IEnumerable<WheelDto>>.Success(
                data: result.Value,
                message: "Wheels fetched successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse<IEnumerable<WheelDto>>.Failure(
            errors,
            "Failed to fetch wheels",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpPatch]
    [Route("UpdateWheel/{id:int}")]
    public async Task<ActionResult<ApiResponse>> UpdateWheel([FromRoute] int id, [FromForm] UpdateWheelCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse.Success(
                message: "Wheel updated successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse.Failure(
            errors,
            "Failed to update wheel",
            HttpStatusCode.BadRequest
        );

        return NotFound(failureResponse);
    }

    [HttpDelete]
    [Route("DeleteWheel/{id:int}")]
    public async Task<ActionResult<ApiResponse>> DeleteWheel([FromRoute] int id)
    {
        var result = await mediator.Send(new DeleteWheelCommand(id));
        if (result.IsSuccess)
        {
            var response = ApiResponse.Success(
                message: "Wheel deleted successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse.Failure(
            errors,
            "Failed to delete wheel",
            HttpStatusCode.BadRequest
        );

        return NotFound(failureResponse);
    }

    [HttpGet]
    [Route("GetWheelById/{id:int}")]
    public async Task<ActionResult<ApiResponse<WheelDto>>> GetWheelById([FromRoute] int id)
    {
        var result = await mediator.Send(new GetWheelByIdQuery(id));
        if (result.IsSuccess)
        {
            var response = ApiResponse<WheelDto>.Success(
                data: result.Value,
                message: "Wheel deleted successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse.Failure(
            errors,
            "Failed to delete wheel",
            HttpStatusCode.BadRequest
        );

        return NotFound(failureResponse);
    }
}
