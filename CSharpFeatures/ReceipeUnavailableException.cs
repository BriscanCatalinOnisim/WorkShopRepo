using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFeatures
{    
    [Serializable]
    public class ReceipeUnavailableException : Exception
    {
        public ReceipeUnavailableException() { }
        public ReceipeUnavailableException(string message) : base(message) { }
        public ReceipeUnavailableException(string message, Exception inner) : base(message, inner) { }
        protected ReceipeUnavailableException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}

