using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.WithRepositories.Application.UseCases.PresentStatistics;

namespace Shop.WithRepositories.Presentation.Pages
{
    public class StatisticsModel : PageModel
    {
        private readonly IMediator mediator;

        public List<SalesStatisticsItemViewModel> SalesStatisticsItems { get; private set; }

        public StatisticsModel(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task OnGetAsync()
        {
            PresentStatisticsRequest request = new PresentStatisticsRequest();
            
            PresentStatisticsResponse response = await mediator.Send(request);

            SalesStatisticsItems = response.SalesStatisticsItems
                .Select(x=> new SalesStatisticsItemViewModel
                {
                    ProductName = x.Product.Name,
                    Quantity = x.Quantity
                });
        }
    }
}