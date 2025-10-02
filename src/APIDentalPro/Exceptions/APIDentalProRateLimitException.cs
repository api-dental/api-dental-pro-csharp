using System.Net.Http;

namespace APIDentalPro.Exceptions;

public class APIDentalProRateLimitException : APIDentalPro4xxException
{
    public APIDentalProRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
