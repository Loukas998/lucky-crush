namespace LuckyCrush.Domain.Response;

public class Result
{
    public bool IsSuccess { get; }
    public string Error { get; } = string.Empty;
    protected Result(string error, bool isSuccess)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new Result(string.Empty, true);
    public static Result Failure(string error) => new Result(error, false);
}

public class Result<T> : Result
{
    public T Value { get; }

    private Result(T value, bool isSuccess, string error)
        : base(error, isSuccess)
    {
        Value = value;
    }

    public static Result<T> Success(T value) => new Result<T>(value, true, string.Empty);
    public static new Result<T> Failure(string error) => new Result<T>(default!, false, error);
}