using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OrderEvents.Queries.GetAll
{
    public class OrderEventsGetAllQueryHandler : IRequestHandler<OrderEventsGetAllQuery, List<OrderEventGetAllDto>>
    {

        private readonly IApplicationDbContext _applicationDbContext;

        public OrderEventsGetAllQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    
        public async Task<List<OrderEventGetAllDto>> Handle(OrderEventsGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbQuery = _applicationDbContext.OrderEvents.AsQueryable();

            dbQuery = dbQuery.Include(x => x.Order);

            var orderEvents = await dbQuery
                .OrderByDescending(x => x.CreatedOn)
                 .Select(x => MapToDto(x))
                .ToListAsync(cancellationToken);

            return orderEvents.ToList();
        }

        private static OrderEventGetAllDto MapToDto(OrderEvent orderEvent)
        {
            return new OrderEventGetAllDto()
            {
                Id = orderEvent.Id,
                OrderId = orderEvent.OrderId,
                Status = orderEvent.Status,
                RequestedAll = orderEvent.Order.RequestedAll,
                RequestedQuantity = orderEvent.Order.RequestedQuantity,
                ActualQuantity = orderEvent.Order.ActualQuantity,
                CreatedOn = orderEvent.Order.CreatedOn,

            };
        }
    }
}
