using System;
using System.Runtime.Serialization;

namespace Shop.WithRepositories.Domain
{
    [Serializable]
    public class ProductAlreadyDispensedException : ShopException
    {
        private const string MessageTemplate = "The product {0} was already dispensed.";

        public ProductAlreadyDispensedException(string productName)
            : base(string.Format(MessageTemplate, productName))
        {
        }

        public ProductAlreadyDispensedException(string productName, Exception inner)
            : base(string.Format(MessageTemplate, productName), inner)
        {
        }

        protected ProductAlreadyDispensedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}