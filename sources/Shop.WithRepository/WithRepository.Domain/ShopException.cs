using System;

namespace Shop.WithRepository.Domain
{
    public class ShopException : Exception
    {
        public ShopException(string message)
            : base(message)
        {
        }
    }
}