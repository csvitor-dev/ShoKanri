namespace ShoKanri.Http;

public class ApiResponse
{
    public static dynamic Ok<T>(T data)
        => new { Success = true, Data = data };

    public static dynamic Fail<T>(T errors)
        => new { Success = false, Errors = errors };
}
