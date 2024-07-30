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
    public class RemoveOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderDetailCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(values);

        }

    }
}
