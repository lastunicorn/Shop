using System;
using System.Runtime.Serialization;
using Shop.WithRepository.Domain;

namespace Shop.WithRepository.Application
{
    [Serializable]
    public class ProductQuantityException : ShopException
    {
        private const string MessageTemplate = "There is no more {0}.";

        public ProductQuantityException(string productName)
            : base(string.Format(MessageTemplate, productName))
        {
        }

        public ProductQuantityException(string productName, Exception inner)
            : base(string.Format(MessageTemplate, productName), inner)
        {
        }

        protected ProductQuantityException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}