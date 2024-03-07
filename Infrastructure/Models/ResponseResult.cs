namespace Infrastructure.Models;

public enum StatusCode
{
    OK = 200,
    ERROR = 400,
    NOT_FOUND = 409,
    EXISTS = 409
}

public class ResponseResult
{
    public StatusCode Status { get; set; }
    public object? ContentResult { get; set; }
    public string? Message { get; set; }
}
