using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using TrendShop.Order.Application.Interfaces;
using TrendShop.Order.Domain.Entities;

namespace TrendShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=>new GetOrderDetailQueryResult
            {
                OrderDetailID = x.OrderDetailID,
                OrderingID = x.OrderingID,
                ProductAmount = x.ProductAmount,
                ProductName = x.ProductName,
                ProductID = x.ProductID,
                ProductPrice = x.ProductPrice,
                ProductTotalPrice = x.ProductTotalPrice
            }).ToList();
        }
    }
}
