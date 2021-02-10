using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.NoRepository.DataAccess.EntityFramework;
using Shop.NoRepository.Domain;

namespace Shop.NoRepository.Application.UseCases.PresentShelf
{
    internal class PresentShelfRequestHandler : IRequestHandler<PresentShelfRequest, List<ProductWithReservations>>
    {
        private readonly ShopDbContext shopDbContext;

        public PresentShelfRequestHandler(ShopDbContext shopDbContext)
        {
            this.shopDbContext = shopDbContext ?? throw new ArgumentNullException(nameof(shopDbContext));
        }

        public Task<List<ProductWithReservations>> Handle(PresentShelfRequest request, CancellationToken cancellationToken)
        {
            // todo: query
            return Task.Run(() => GetAvailable().ToList(), cancellationToken);
        }

        public IEnumerable<ProductWithReservations> GetAvailable()
        {
            IQueryable<ProductWithReservations> query = shopDbContext.Products
                .Select(x => new ProductWithReservations
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    ReservationCount = shopDbContext.Orders.Count(z => z.Product == x && z.State != OrderState.Done && z.State != OrderState.Canceled)
                });

            foreach (ProductWithReservations productWithReservations in query)
            {
                shopDbContext.Set<ProductWithReservations>().Attach(productWithReservations);
                yield return productWithReservations;
            }
        }
    }
}