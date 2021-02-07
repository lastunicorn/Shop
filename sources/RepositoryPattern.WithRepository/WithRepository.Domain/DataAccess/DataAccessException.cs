namespace Shop.WithRepository.Domain.DataAccess
{
    public class DataAccessException : ShopException
    {
        public DataAccessException(string message)
            : base(message)
        {
        }
    }
}