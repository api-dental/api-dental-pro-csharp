using System.Net.Http;

namespace ApiDentalPro.Exceptions;

public class ApiDentalProForbiddenException : ApiDentalPro4xxException
{
    public ApiDentalProForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
