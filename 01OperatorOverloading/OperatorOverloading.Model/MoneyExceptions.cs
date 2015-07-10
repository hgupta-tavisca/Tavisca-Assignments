  using System;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Runtime.Serialization;

namespace OperatorOverloading.dbl
{
    [Serializable]
    public class MoneyException : Exception
    {
        public MoneyException()
        {
        }
        public MoneyException(string message)
            : base(message)
        {
        }
        public MoneyException(string message, Exception inner)
            : base(message, inner)
        {
        }
        protected MoneyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }

}
