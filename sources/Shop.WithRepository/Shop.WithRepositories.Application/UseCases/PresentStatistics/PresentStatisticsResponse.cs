using System.Collections.Generic;

namespace Shop.WithRepositories.Application.UseCases.PresentStatistics
{
    public class PresentStatisticsResponse
    {
        public List<SalesStatisticsItem> SalesStatisticsItems { get; set; }
    }
}