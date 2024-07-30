using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using TrendShop.Order.Application.Interfaces;
using TrendShop.Order.Domain.Entities;

namespace TrendShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand createOrderDetailCommand)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                OrderingID = createOrderDetailCommand.OrderingID,
                ProductAmount = createOrderDetailCommand.ProductAmount,
                ProductID = createOrderDetailCommand.ProductID,
                ProductPrice = createOrderDetailCommand.ProductPrice,
                ProductName = createOrderDetailCommand.ProductName,
                ProductTotalPrice = createOrderDetailCommand.ProductTotalPrice
            });
        }
    }
}
