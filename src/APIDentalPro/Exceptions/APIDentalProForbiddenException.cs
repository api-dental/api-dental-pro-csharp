using System.Net.Http;

namespace APIDentalPro.Exceptions;

public class APIDentalProForbiddenException : APIDentalPro4xxException
{
    public APIDentalProForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
