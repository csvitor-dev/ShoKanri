using System.Net;
using ShoKanri.Exception.Base;

namespace ShoKanri.Exception.Project;

public sealed class NotFoundException
    (string message) : ProjectException(HttpStatusCode.NotFound, [message]);
