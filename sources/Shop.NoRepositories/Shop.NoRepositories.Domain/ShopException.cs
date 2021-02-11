using System;
using System.Runtime.Serialization;

namespace Shop.NoRepositories.Domain
{
    [Serializable]
    public class ShopException : Exception
    {
        public ShopException()
        {
        }

        public ShopException(string message)
            : base(message)
        {
        }

        public ShopException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ShopException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}