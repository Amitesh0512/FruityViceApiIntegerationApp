using System.Net;

namespace FruityViceApiIntegerationApp.Exceptions
{
    public class FruityViceApiException: Exception
    {
        public HttpStatusCode StatusCode { get; }

        public FruityViceApiException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
