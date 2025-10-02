using LuckyCrush.Application.Prizes.Commands.Create;
using LuckyCrush.Application.Prizes.Commands.Delete;
using LuckyCrush.Application.Prizes.Commands.Update;
using LuckyCrush.Application.Prizes.Dtos;
using LuckyCrush.Application.Prizes.Queries.GetAll;
using LuckyCrush.Application.Wheels.Commands.AssignPrizes;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LuckyCrush.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrizeController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Route("CreatePrize")]
    public async Task<ActionResult<ApiResponse<PrizeDto>>> CreatePrize([FromForm] CreatePrizeCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse<PrizeDto>.Success(
                data: result.Value,
                message: "Prize created successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse<PrizeDto>.Failure(
            errors,
            "Failed to create prize",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpGet]
    [Route("GetAllPrizes")]
    public async Task<ActionResult<ApiResponse<IEnumerable<PrizeDto>>>> GetAllPrizes()
    {
        var result = await mediator.Send(new GetAllPrizesQuery());
        if (result.IsSuccess)
        {
            var response = ApiResponse<IEnumerable<PrizeDto>>.Success(
                data: result.Value,
                message: "Prizes fetched successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse<IEnumerable<PrizeDto>>.Failure(
            errors,
            "Failed to fetch prizes",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpPatch]
    [Route("UpdatePrize/{id:int}")]
    public async Task<ActionResult<ApiResponse>> UpdatePrize([FromRoute] int id, [FromForm] UpdatePrizeCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse.Success(
                message: "Prize updated successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse.Failure(
            errors,
            "Failed to update prize",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpDelete]
    [Route("DeletePrize/{id:int}")]
    public async Task<ActionResult<ApiResponse>> DeletePrize([FromRoute] int id)
    {
        var result = await mediator.Send(new DeletePrizeCommand(id));
        if (result.IsSuccess)
        {
            var response = ApiResponse.Success(
                message: "Prize deleted successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse.Failure(
            errors,
            "Failed to delete prize",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpPost]
    [Route("AssignPrizeToPlayer")]
    public async Task<ActionResult<ApiResponse>> AssignPrizeToPlayer([FromBody] AssignPrizesCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse.Success(
                message: "Prize assigned to player successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse.Failure(
            errors,
            "Failed to assign prize to player",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }
}
