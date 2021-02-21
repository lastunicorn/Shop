using System;
using System.Runtime.Serialization;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.Application
{
    [Serializable]
    public class OrderMissingException : ShopException
    {
        private const string MessageTemplate = "The order with id ({0}) does not exist.";

        public OrderMissingException(Guid orderId)
            : base(string.Format(MessageTemplate, orderId))
        {
        }

        public OrderMissingException(Guid orderId, Exception inner)
            : base(string.Format(MessageTemplate, orderId), inner)
        {
        }

        protected OrderMissingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}