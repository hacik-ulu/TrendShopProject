using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using TrendShop.Order.Application.Interfaces;
using TrendShop.Order.Domain.Entities;

namespace TrendShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var values = await _repository.GetByIdAsync(updateAddressCommand.AddressID);
            values.Detail = updateAddressCommand.Detail;
            values.District = updateAddressCommand.District;
            values.City = updateAddressCommand.City;
            values.UserID = updateAddressCommand.UserID;
            await _repository.UpdateAsync(values);
        }
    }
}
