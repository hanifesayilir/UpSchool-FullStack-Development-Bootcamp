using Application.Common.Interfaces;
using Application.Common.Models.General;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Orders.Queries.GetAll
{
    public class OrderGetAllQueryHandler:IRequestHandler<OrderGetAllQuery, PaginatedList<OrderGetAllDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public OrderGetAllQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext= applicationDbContext;
        }

        public async Task<PaginatedList<OrderGetAllDto>> Handle(OrderGetAllQuery request, CancellationToken cancellationToken)
        {
            var orderDtos = await _applicationDbContext.Orders
            .Select(x => new OrderGetAllDto( x.Id, x.RequestedAll, x.RequestedQuantity, x.ActualQuantity, x.ProductCrawlType))
            .AsNoTracking()
            .ToListAsync(cancellationToken);

            return PaginatedList<OrderGetAllDto>.Create(orderDtos, request.PageNumber, request.PageSize);
        }
    }
}
