using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Von.Crate.Core
{
    public class CrateException : Exception
    {
        public CrateException()
        {
        }

        public CrateException(string? message) : base(message)
        {
        }

        public CrateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CrateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
