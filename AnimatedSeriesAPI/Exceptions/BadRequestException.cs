using System;

namespace AnimatedSeriesAPI.Middleware
{
    [Serializable]
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}