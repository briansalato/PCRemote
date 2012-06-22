using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Remote.Web.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() { }
        public ValidationException(string message) : base(message) { }
    }
}