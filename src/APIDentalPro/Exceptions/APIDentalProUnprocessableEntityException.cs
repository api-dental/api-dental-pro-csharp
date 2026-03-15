using System.Net.Http;

namespace APIDentalPro.Exceptions;

public class APIDentalProUnprocessableEntityException : APIDentalPro4xxException
{
    public APIDentalProUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
