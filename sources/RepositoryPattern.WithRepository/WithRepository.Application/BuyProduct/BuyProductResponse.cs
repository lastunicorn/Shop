namespace RepositoryPattern.WithRepository.Application.BuyProduct
{
    public class BuyProductResponse
    {
        public BuyState BuyState { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }
    }
}