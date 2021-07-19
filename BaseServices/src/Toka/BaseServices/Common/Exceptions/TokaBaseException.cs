using System;

namespace Toka.BaseServices.Common.Exceptions
{
    public class TokaBaseException : Exception
    {
        public TokaBaseException(string message) : base(message) { }

        public TokaBaseException(string message, Exception innerException) : base(message, innerException)
        {

        }
}
}
