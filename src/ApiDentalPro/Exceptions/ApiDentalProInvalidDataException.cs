using System;

namespace ApiDentalPro.Exceptions;

public class ApiDentalProInvalidDataException : ApiDentalProException
{
    public ApiDentalProInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
