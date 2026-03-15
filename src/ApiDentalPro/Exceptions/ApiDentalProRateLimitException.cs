using System.Net.Http;

namespace ApiDentalPro.Exceptions;

public class ApiDentalProRateLimitException : ApiDentalPro4xxException
{
    public ApiDentalProRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
