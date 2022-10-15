using System.Net;

namespace Application.Common.Errors
{
    public interface IServiceException
    {
        HttpStatusCode StatusCode { get; } 
        string ErrorMessage { get; } 
    }
}
