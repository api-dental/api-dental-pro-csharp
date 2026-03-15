using System;
using System.Net.Http;

namespace ApiDentalPro.Exceptions;

public class ApiDentalProIOException : ApiDentalProException
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

    public ApiDentalProIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
