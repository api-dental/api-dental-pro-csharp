using System.Net.Http;

namespace ApiDentalPro.Exceptions;

public class ApiDentalPro4xxException : ApiDentalProApiException
{
    public ApiDentalPro4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
