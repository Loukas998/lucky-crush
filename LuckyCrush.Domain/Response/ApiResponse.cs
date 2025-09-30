using System.Net;

namespace LuckyCrush.Domain.Response;

public class ApiResponse<T>
{
    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
    public List<ApiError>? Errors { get; set; }

    public static ApiResponse<T> Success(T data, string message = "", HttpStatusCode statusCode = HttpStatusCode.OK)
        => new()
        {
            IsSuccess = true,
            StatusCode = (int)statusCode,
            Data = data,
            Message = message,
            Errors = null
        };

    public static ApiResponse<T> Failure(List<ApiError> errors, string message = "", HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        => new()
        {
            IsSuccess = false,
            StatusCode = (int)statusCode,
            Data = default,
            Message = message,
            Errors = errors
        };
}

public class ApiResponse
{
    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<ApiError>? Errors { get; set; }

    public static ApiResponse Success(string message = "", HttpStatusCode statusCode = HttpStatusCode.OK)
        => new()
        {
            IsSuccess = true,
            StatusCode = (int)statusCode,
            Message = message,
            Errors = null
        };

    public static ApiResponse Failure(List<ApiError> errors, string message = "", HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        => new()
        {
            IsSuccess = false,
            StatusCode = (int)statusCode,
            Message = message,
            Errors = errors
        };
}


public class ApiError
{
    public string Description { get; set; } = string.Empty;
}