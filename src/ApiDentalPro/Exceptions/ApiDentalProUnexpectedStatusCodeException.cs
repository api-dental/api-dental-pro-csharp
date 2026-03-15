using System.Net.Http;

namespace ApiDentalPro.Exceptions;

public class ApiDentalProUnexpectedStatusCodeException : ApiDentalProApiException
{
    public ApiDentalProUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
