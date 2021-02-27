using System;
using System.Runtime.Serialization;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.Application
{
    [Serializable]
    public class ProductMissingException : ShopException
    {
        private const string MessageTemplate = "There is no product with the id {0}.";

        public ProductMissingException(int productId)
            : base(string.Format(MessageTemplate, productId))
        {
        }

        public ProductMissingException(int productId, Exception inner)
            : base(string.Format(MessageTemplate, productId), inner)
        {
        }

        protected ProductMissingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
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