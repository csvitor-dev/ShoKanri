namespace ShoKanri.Http;

public class ApiResponse
{
    public static dynamic Ok<T>(T data)
        => new { Success = true, Data = data };

    public static dynamic Fail(IList<string> errors)
        => new { Success = false, Errors = errors };
}
