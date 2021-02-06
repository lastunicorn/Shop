﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.WithRepository.Domain;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository.Application.GetProducts
{
    public class GetProductsRequestHandler : IRequestHandler<GetProductsRequest, List<Product>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetProductsRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Task<List<Product>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() => unitOfWork.ProductRepository.GetAll().ToList(), cancellationToken);
        }
    }
}