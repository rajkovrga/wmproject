using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BlogService.Exceptions
{
    public class ModelNotFoundException : Exception
    {
        public ModelNotFoundException()
        {
        }

        public ModelNotFoundException(string message) : base(message)
        {
        }

        public ModelNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModelNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
