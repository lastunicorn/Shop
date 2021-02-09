using System;
using System.Runtime.Serialization;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.Application
{
    [Serializable]
    public class OrderNotPayedException : ShopException
    {
        private const string MessageTemplate = "The order with id ({0}) is not payed.";

        public OrderNotPayedException(int orderId)
            : base(string.Format(MessageTemplate, orderId))
        {
        }

        public OrderNotPayedException(int orderId, Exception inner)
            : base(string.Format(MessageTemplate, orderId), inner)
        {
        }

        protected OrderNotPayedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}