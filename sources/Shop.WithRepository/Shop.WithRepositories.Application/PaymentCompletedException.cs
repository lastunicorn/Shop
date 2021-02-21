using System;
using System.Runtime.Serialization;
using Shop.WithRepositories.Domain;

namespace Shop.WithRepositories.Application
{
    [Serializable]
    public class PaymentCompletedException : ShopException
    {
        private const string MessageTemplate = "The payment for order {0:D} was already completed.";

        public PaymentCompletedException(Guid orderId)
            : base(string.Format(MessageTemplate, orderId))
        {
        }

        public PaymentCompletedException(Guid orderId, Exception inner)
            : base(string.Format(MessageTemplate, orderId), inner)
        {
        }

        protected PaymentCompletedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}