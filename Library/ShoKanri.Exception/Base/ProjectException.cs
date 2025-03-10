using System.Net;
namespace ShoKanri.Exception.Base;

public class ProjectException: ApplicationException
{
    public HttpStatusCode StatusCode { get; set; }

}



