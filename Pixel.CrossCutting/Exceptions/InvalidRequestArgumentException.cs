using System;

namespace Pixel.CrossCutting.Exceptions
{
    public class InvalidRequestArgumentException : Exception
    {
        public InvalidRequestArgumentException(string message) : base(message)
        {
        }
    }
}
