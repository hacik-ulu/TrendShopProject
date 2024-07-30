using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using TrendShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using TrendShop.Order.Application.Interfaces;
using TrendShop.Order.Domain.Entities;

namespace TrendShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResult
            {
                OrderDetailID = values.OrderDetailID,
                OrderingID = values.OrderingID,
                ProductAmount = values.ProductAmount,
                ProductID = values.ProductID,
                ProductPrice = values.ProductPrice,
                ProductTotalPrice = values.ProductTotalPrice,
                ProductName = values.ProductName
            };
        }
    }
}
