using Shop.WithRepositories.Domain;

namespace Shop.WithRepositories.Application.UseCases.PresentStatistics
{
    public class SalesStatisticsItem
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}