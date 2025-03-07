namespace ShoKanri.Http.Responses;

public class ValidationErrorResponse : ErrorResponse
{
    public Dictionary<string, List<string>> FieldErrors { get; set; } = new();
}
