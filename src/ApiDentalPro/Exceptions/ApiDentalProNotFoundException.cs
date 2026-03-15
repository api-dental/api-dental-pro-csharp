using System.Net.Http;

namespace ApiDentalPro.Exceptions;

public class ApiDentalProNotFoundException : ApiDentalPro4xxException
{
    public ApiDentalProNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
