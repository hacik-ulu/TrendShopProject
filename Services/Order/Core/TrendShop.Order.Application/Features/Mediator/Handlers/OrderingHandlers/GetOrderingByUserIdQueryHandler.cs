using MediatR;
using TrendShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using TrendShop.Order.Application.Features.Mediator.Results;
using TrendShop.Order.Application.Features.Mediator.Results.OrderingResults;
using TrendShop.Order.Application.Interfaces;
using TrendShop.Order.Domain.Entities;

namespace TrendShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByUserIdQueryHandler : IRequestHandler<GetOrderingByUserIdQuery, List<GetOrderingByUserIdQueryResult>>
    {
        private readonly IOrderingRepository _orderingRepository;
        public GetOrderingByUserIdQueryHandler(IOrderingRepository orderingRepository)
        {
            _orderingRepository = orderingRepository;
        }

        public async Task<List<GetOrderingByUserIdQueryResult>> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
        {
            var values = _orderingRepository.GetOrderingsByUserId(request.Id);
            return values.Select(x => new GetOrderingByUserIdQueryResult
            {
                OrderDate = x.OrderDate,
                OrderingID = x.OrderingID,
                TotalPrice = x.TotalPrice,
                UserID = x.UserID,
            }).ToList();
        }
    }
}
