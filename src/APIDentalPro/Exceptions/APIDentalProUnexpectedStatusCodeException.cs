using System.Net.Http;

namespace APIDentalPro.Exceptions;

public class APIDentalProUnexpectedStatusCodeException : APIDentalProApiException
{
    public APIDentalProUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
