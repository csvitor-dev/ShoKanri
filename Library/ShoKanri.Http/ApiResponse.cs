namespace ShoKanri.Http;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public List<string> Errors { get; set; } = new();

    public static ApiResponse<T> Ok(T data) => new() { Success = true, Data = data };
    public static ApiResponse<T> Fail(List<string> errors) => new() { Success = false, Errors = errors };
}
