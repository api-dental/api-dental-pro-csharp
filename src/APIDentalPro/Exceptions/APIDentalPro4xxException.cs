using System.Net.Http;

namespace APIDentalPro.Exceptions;

public class APIDentalPro4xxException : APIDentalProApiException
{
    public APIDentalPro4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
