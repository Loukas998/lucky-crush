using LuckyCrush.Application.Categories.Commands.Create;
using LuckyCrush.Application.Categories.Commands.Delete;
using LuckyCrush.Application.Categories.Commands.Update;
using LuckyCrush.Application.Categories.Dtos;
using LuckyCrush.Application.Categories.Queries.GetAll;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LuckyCrush.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Route("CreateCategory")]
    public async Task<ActionResult<ApiResponse<CategoryDto>>> CreateCategory([FromForm] CreateCategoryCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse<CategoryDto>.Success(
                data: result.Value,
                message: "Category created successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse<CategoryDto>.Failure(
            errors,
            "Failed to create category",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpGet]
    [Route("GetAllCategories")]
    public async Task<ActionResult<ApiResponse<IEnumerable<CategoryDto>>>> GetAllCategories()
    {
        var result = await mediator.Send(new GetAllCategoriesQuery());
        if (result.IsSuccess)
        {
            var response = ApiResponse<IEnumerable<CategoryDto>>.Success(
                data: result.Value,
                message: "Categories fetched successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse<IEnumerable<CategoryDto>>.Failure(
            errors,
            "Failed to fetch categories",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpPatch]
    [Route("UpdateCategory/{id:int}")]
    public async Task<ActionResult<ApiResponse>> UpdateCategory([FromRoute] int id, [FromForm] UpdateCategoryCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            var response = ApiResponse.Success(
                message: "Category updated successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse.Failure(
            errors,
            "Failed to update category",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }

    [HttpDelete]
    [Route("DeleteCategory/{id:int}")]
    public async Task<ActionResult<ApiResponse>> DeleteCategory([FromRoute] int id)
    {
        var result = await mediator.Send(new DeleteCategoryCommand(id));
        if (result.IsSuccess)
        {
            var response = ApiResponse.Success(
                message: "Category deleted successfully",
                statusCode: HttpStatusCode.OK
            );
            return Ok(response);
        }

        var errors = new List<ApiError> { new() { Description = result.Error } };

        var failureResponse = ApiResponse.Failure(
            errors,
            "Failed to delete category",
            HttpStatusCode.BadRequest
        );

        return BadRequest(failureResponse);
    }
}
