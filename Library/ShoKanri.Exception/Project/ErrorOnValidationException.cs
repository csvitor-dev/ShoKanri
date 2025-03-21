using System.Net;
using ShoKanri.Exception.Base;

namespace ShoKanri.Exception.Project;

public sealed class ErrorOnValidationException
    (IList<string> messages, HttpStatusCode status = HttpStatusCode.BadRequest) : ProjectException(status)
{
    public override IList<string> GetErrorMessages()
        => messages;
}
