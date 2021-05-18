using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.WithRepositories.Domain;
using Shop.WithRepositories.Domain.DataAccess;

namespace Shop.WithRepositories.Application.UseCases.PresentStatistics
{
    public class PresentStatisticsRequestHandler : IRequestHandler<PresentStatisticsRequest, PresentStatisticsResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        public PresentStatisticsRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Task<PresentStatisticsResponse> Handle(PresentStatisticsRequest request, CancellationToken cancellationToken)
        {
            List<SalesStatisticsItem> saleStatistics = GetSalesStatistics();
            
            PresentStatisticsResponse response = new PresentStatisticsResponse
            {
                SalesStatisticsItems = saleStatistics
            };

            return Task.FromResult(response);
        }

        private List<SalesStatisticsItem> GetSalesStatistics()
        {
            Dictionary<Product, int> items = unitOfWork.OrderRepository.GetFinishedCountByProduct();
            return items
                .Select(x => new SalesStatisticsItem
                {
                    Product = x.Key,
                    Quantity = x.Value
                })
                .ToList();
        }
    }
}