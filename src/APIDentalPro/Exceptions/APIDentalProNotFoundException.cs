using System.Net.Http;

namespace APIDentalPro.Exceptions;

public class APIDentalProNotFoundException : APIDentalPro4xxException
{
    public APIDentalProNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
