using System;

namespace App.Domain.Infrastructure.Exceptions
{
    /// <summary>
    /// Exception class used to identify fetch error
    /// </summary>
    public class PeopleFetchException : Exception
    {
        public PeopleFetchException() { }
        public PeopleFetchException(string message) : base(message) { }
        public PeopleFetchException(string message, Exception inner) : base(message, inner) { }
    }
}

