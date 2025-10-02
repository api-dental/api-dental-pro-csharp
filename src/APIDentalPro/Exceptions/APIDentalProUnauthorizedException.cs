using System.Net.Http;

namespace APIDentalPro.Exceptions;

public class APIDentalProUnauthorizedException : APIDentalPro4xxException
{
    public APIDentalProUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
