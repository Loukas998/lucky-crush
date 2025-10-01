using LuckyCrush.Application.Spins.Commands.Create;
using LuckyCrush.Application.Spins.Dtos;
using LuckyCrush.Application.Spins.Queries.GetAll;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LuckyCrush.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpinController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Route("Spin")]
    public async Task<ActionResult<ApiResponse<SpinDto>>> Spin([FromBody] CreateSpinCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse<SpinDto>.Success(
                data: result.Value,
                message: "Spin stored successfully",
                HttpStatusCode.OK
            );
            return Ok(response);
        }
        var errors = new List<ApiError>
        {
            new() { Description = result.Error }
        };

        var failureResponse = ApiResponse<SpinDto>.Failure(
            errors,
            "Failed to create player",
            HttpStatusCode.BadRequest
        );
        return BadRequest(failureResponse);
    }

    [HttpGet]
    [Route("GetAllSpins")]
    public async Task<ActionResult<ApiResponse<IEnumerable<SpinDto>>>> GetAllSpins()
    {
        var result = await mediator.Send(new GetAllSpinsQuery());
        if (result.IsSuccess)
        {
            var response = ApiResponse<IEnumerable<SpinDto>>.Success(
                data: result.Value,
                message: "Spins retrieved successfully",
                HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError>
        {
            new() { Description = result.Error }
        };

        var failureResponse = ApiResponse<SpinDto>.Failure(
            errors,
            "Failed to create player",
            HttpStatusCode.BadRequest
        );
        return BadRequest(failureResponse);
    }
}
