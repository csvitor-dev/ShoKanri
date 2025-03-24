using System.Net;
namespace ShoKanri.Exception.Base;

public abstract class ProjectException
    (HttpStatusCode status, IList<string> errorMessages) : ApplicationException
{
    private readonly IList<string> _errors = errorMessages;

    public int StatusCode { get => Convert.ToInt32(status); }

    public IList<string> GetErrorMessages()
        => _errors;
}
