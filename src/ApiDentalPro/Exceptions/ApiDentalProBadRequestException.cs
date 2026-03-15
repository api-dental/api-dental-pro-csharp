using System.Net.Http;

namespace ApiDentalPro.Exceptions;

public class ApiDentalProBadRequestException : ApiDentalPro4xxException
{
    public ApiDentalProBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
