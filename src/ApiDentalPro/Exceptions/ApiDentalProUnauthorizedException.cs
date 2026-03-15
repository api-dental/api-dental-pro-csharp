using System.Net.Http;

namespace ApiDentalPro.Exceptions;

public class ApiDentalProUnauthorizedException : ApiDentalPro4xxException
{
    public ApiDentalProUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
