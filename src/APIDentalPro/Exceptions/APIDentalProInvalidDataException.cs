using System;

namespace APIDentalPro.Exceptions;

public class APIDentalProInvalidDataException : APIDentalProException
{
    public APIDentalProInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
