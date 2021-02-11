using System;
using System.Runtime.Serialization;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.Application
{
    [Serializable]
    public class OrderMissingException : ShopException
    {
        private const string MessageTemplate = "The order with id ({0}) does not exist.";

        public OrderMissingException(int orderId)
            : base(string.Format(MessageTemplate, orderId))
        {
        }

        public OrderMissingException(int orderId, Exception inner)
            : base(string.Format(MessageTemplate, orderId), inner)
        {
        }

        protected OrderMissingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}