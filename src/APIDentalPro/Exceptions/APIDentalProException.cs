using System;
using System.Net.Http;

namespace APIDentalPro.Exceptions;

public class APIDentalProException : Exception
{
    public APIDentalProException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected APIDentalProException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
