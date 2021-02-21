using System;
using System.Runtime.Serialization;
using Shop.WithRepositories.Domain;

namespace Shop.WithRepositories.Application
{
    [Serializable]
    public class OrderCanceledException : ShopException
    {
        private const string MessageTemplate = "The order with id {0:D} was canceled.";

        public OrderCanceledException(Guid orderId)
            : base(string.Format(MessageTemplate, orderId))
        {
        }

        public OrderCanceledException(Guid orderId, Exception inner)
            : base(string.Format(MessageTemplate, orderId), inner)
        {
        }

        protected OrderCanceledException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}