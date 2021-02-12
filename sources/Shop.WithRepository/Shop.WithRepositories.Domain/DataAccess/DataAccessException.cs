namespace Shop.WithRepositories.Domain.DataAccess
{
    public class DataAccessException : ShopException
    {
        public DataAccessException(string message)
            : base(message)
        {
        }
    }
}