using System.Net;
namespace ShoKanri.Exception.Base;

public abstract class ProjectException(HttpStatusCode status) : ApplicationException
{
    public int StatusCode { get => Convert.ToInt32(status); }

    public abstract IList<string> GetErrorMessages();
}
