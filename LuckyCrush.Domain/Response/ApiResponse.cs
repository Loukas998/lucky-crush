namespace LuckyCrush.Domain.Response;

public class ApiResponse<T>
{
    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
    public List<ApiError>? Errors { get; set; }
}


public class ApiError
{
    public string Description { get; set; } = string.Empty;
}