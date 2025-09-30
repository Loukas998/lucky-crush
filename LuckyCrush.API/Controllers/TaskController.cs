using LuckyCrush.Application.Matches.Dtos;
using LuckyCrush.Application.Tasks.Commands.Create;
using LuckyCrush.Application.Tasks.Commands.Delete;
using LuckyCrush.Application.Tasks.Commands.Update;
using LuckyCrush.Application.Tasks.Dtos;
using LuckyCrush.Application.Tasks.Queries.GetAll;
using LuckyCrush.Application.Tasks.Queries.GetById;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LuckyCrush.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<ApiResponse<GoalTaskDto>>> CreateTask([FromBody] CreateTaskCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse<GoalTaskDto>.Success(
                data: result.Value,
                message: "Task created",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError>()
        {
            new () { Description = result.Error }
        };

        var failureResponse = ApiResponse<MatchDto>.Failure(
            errors,
            "Failed to store match",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiResponse<GoalTaskDto>>> GetTaskById([FromRoute] int id)
    {
        var result = await mediator.Send(new GetTaskByIdQuery(id));
        if (result.IsSuccess)
        {
            var response = ApiResponse<GoalTaskDto>.Success(
                data: result.Value,
                message: "Task created",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError>()
        {
            new () { Description = result.Error }
        };

        var failureResponse = ApiResponse<MatchDto>.Failure(
            errors,
            "Failed to store match",
            HttpStatusCode.NotFound
        );

        return NotFound(failureResponse);
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<GoalTaskDto>>>> GetAllTasks()
    {
        var result = await mediator.Send(new GetAllTasksQuery());
        if (result.IsSuccess)
        {
            var response = ApiResponse<IEnumerable<GoalTaskDto>>.Success(
                data: result.Value,
                message: "Task created",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError>()
        {
            new () { Description = result.Error }
        };

        var failureResponse = ApiResponse<MatchDto>.Failure(
            errors,
            "Failed to store match",
            HttpStatusCode.NotFound
        );

        return NotFound(failureResponse);
    }

    [HttpPatch("{id:int}")]
    public async Task<ActionResult<ApiResponse>> UpdateTask([FromRoute] int id, [FromBody] UpdateTaskCommand command)
    {
        command.TaskId = id;
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse.Success(
                message: "Task updated",
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
            "Failed to store match",
            HttpStatusCode.NotFound
        );

        return NotFound(failureResponse);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ApiResponse>> DeleteTask([FromRoute] int id)
    {
        var result = await mediator.Send(new DeleteTaskCommand(id));
        if (result.IsSuccess)
        {
            var response = ApiResponse.Success(
                message: "Task updated",
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
            "Failed to store match",
            HttpStatusCode.NotFound
        );

        return NotFound(failureResponse);
    }
}
