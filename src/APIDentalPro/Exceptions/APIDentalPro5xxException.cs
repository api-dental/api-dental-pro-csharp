using System.Net.Http;

namespace APIDentalPro.Exceptions;

public class APIDentalPro5xxException : APIDentalProApiException
{
    public APIDentalPro5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
