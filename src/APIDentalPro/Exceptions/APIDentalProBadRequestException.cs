using System.Net.Http;

namespace APIDentalPro.Exceptions;

public class APIDentalProBadRequestException : APIDentalPro4xxException
{
    public APIDentalProBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
