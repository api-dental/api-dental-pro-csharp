using System;
using System.Net.Http;

namespace APIDentalPro.Exceptions;

public class APIDentalProIOException : APIDentalProException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public APIDentalProIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
