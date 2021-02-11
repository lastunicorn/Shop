using System;
using System.Runtime.Serialization;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.Application
{
    [Serializable]
    public class OrderCanceledException : ShopException
    {
        private const string MessageTemplate = "The order with id {0} was canceled.";

        public OrderCanceledException(int orderId)
            : base(string.Format(MessageTemplate, orderId))
        {
        }

        public OrderCanceledException(int orderId, Exception inner)
            : base(string.Format(MessageTemplate, orderId), inner)
        {
        }

        protected OrderCanceledException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}