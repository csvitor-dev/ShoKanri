using System.Net;
using ShoKanri.Exception.Base;

namespace ShoKanri.Exception.Project;

public sealed class ErrorOnValidationException : ProjectException
{
    private readonly IList<string> _errors = [];

    public ErrorOnValidationException(string message, HttpStatusCode status = HttpStatusCode.BadRequest)
        : base(status)
        => _errors.Append(message);

    public ErrorOnValidationException(IList<string> messages, HttpStatusCode status = HttpStatusCode.BadRequest)
        : base(status)
        => _errors = messages;

    public override IList<string> GetErrorMessages()
        => _errors;
}
