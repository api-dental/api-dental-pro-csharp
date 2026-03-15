using System;
using System.Net.Http;

namespace ApiDentalPro.Exceptions;

public class ApiDentalProException : Exception
{
    public ApiDentalProException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected ApiDentalProException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
