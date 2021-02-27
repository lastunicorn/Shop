using System;
using System.Runtime.Serialization;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.Application
{
    [Serializable]
    public class OrderNotPayedException : ShopException
    {
        private const string MessageTemplate = "The order with id ({0}) is not payed.";

        public OrderNotPayedException(Guid orderId)
            : base(string.Format(MessageTemplate, orderId))
        {
        }

        public OrderNotPayedException(Guid orderId, Exception inner)
            : base(string.Format(MessageTemplate, orderId), inner)
        {
        }

        protected OrderNotPayedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}