using System;
using System.Runtime.Serialization;
using Shop.WithRepositories.Domain;

namespace Shop.WithRepositories.Application
{
    [Serializable]
    public class InvalidOrderStateException : ShopException
    {
        private const string MessageTemplate = "The order with id {0:D} has an invalid state.";

        public InvalidOrderStateException(Guid orderId)
            : base(string.Format(MessageTemplate, orderId))
        {
        }

        public InvalidOrderStateException(Guid orderId, Exception inner)
            : base(string.Format(MessageTemplate, orderId), inner)
        {
        }

        protected InvalidOrderStateException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}