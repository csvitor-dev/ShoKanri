using System.Net;
using ShoKanri.Exception.Base;

namespace ShoKanri.Exception.Project;

public sealed class ErrorOnValidationException : ProjectException
{
    public ErrorOnValidationException(string message)
        : base(HttpStatusCode.BadRequest, [message]) { }

    public ErrorOnValidationException(IList<string> messages)
        : base(HttpStatusCode.BadRequest, messages) { }
}
