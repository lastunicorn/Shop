using System;
using System.Runtime.Serialization;
using Shop.NoRepositories.Domain;

namespace Shop.NoRepositories.Application.UseCases.BeginOrder
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
}