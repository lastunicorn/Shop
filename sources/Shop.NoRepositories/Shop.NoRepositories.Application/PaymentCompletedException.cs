using System;
using System.Runtime.Serialization;
using Shop.NoRepository.Domain;

namespace Shop.NoRepository.Application
{
    [Serializable]
    public class PaymentCompletedException : ShopException
    {
        private const string MessageTemplate = "The payment for order {0} was already completed.";

        public PaymentCompletedException(int orderId)
            : base(string.Format(MessageTemplate, orderId))
        {
        }

        public PaymentCompletedException(int orderId, Exception inner)
            : base(string.Format(MessageTemplate, orderId), inner)
        {
        }

        protected PaymentCompletedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}