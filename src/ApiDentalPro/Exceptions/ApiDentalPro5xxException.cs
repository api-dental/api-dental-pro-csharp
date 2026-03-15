using System.Net.Http;

namespace ApiDentalPro.Exceptions;

public class ApiDentalPro5xxException : ApiDentalProApiException
{
    public ApiDentalPro5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
