

using System;

namespace NorthWind.Application.Exceptions
{
    public class CustomerServiceException : Exception
    {
        public CustomerServiceException(string message):base(message)
        {

        }
    }
}
