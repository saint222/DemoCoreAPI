using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DemoCoreAPI.BusinessLogic.Errors
{
    [Serializable]
    public class EmailDuplicateException : Exception
    {
        public EmailDuplicateException() { }
        public EmailDuplicateException(string message) : base(message) { }

        public EmailDuplicateException(string message, Exception innerException) : base(message, innerException) { }

        protected EmailDuplicateException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
