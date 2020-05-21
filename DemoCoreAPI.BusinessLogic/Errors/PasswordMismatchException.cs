using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DemoCoreAPI.BusinessLogic.Errors
{
    [Serializable]
    public class PasswordMismatchException : Exception
    {
        public PasswordMismatchException() { }
        public PasswordMismatchException(string message) : base(message) { }

        public PasswordMismatchException(string message, Exception innerException) : base(message, innerException) { }

        protected PasswordMismatchException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
