using System.Net.Http;

namespace ApiDentalPro.Exceptions;

public class ApiDentalProUnprocessableEntityException : ApiDentalPro4xxException
{
    public ApiDentalProUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
