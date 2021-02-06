using System;

namespace Shop.WithRepository.Domain.DataAccess
{
    public class DataAccessException : Exception
    {
        public DataAccessException(string message)
            : base(message)
        {
        }
    }
}