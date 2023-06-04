using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Orders.Commands.Add
{
    public class OrderAddCommandHandler : IRequestHandler<OrderAddCommand, Response<Guid>>
    {

        private readonly IApplicationDbContext _applicationDbContext;

        public OrderAddCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    
        public async Task<Response<Guid>> Handle(OrderAddCommand request, CancellationToken cancellationToken)
        {
            var order = new Order()
            {
                Id = request.Id,
                RequestedAll = request.RequestedAll,
                RequestedQuantity= request.RequestedQuantity,
                ProductCrawlType= request.ProductCrawlType,
                CreatedOn = DateTimeOffset.Now,
                CreatedByUserId = null,
                IsDeleted = false,
            };

        await _applicationDbContext.Orders.AddAsync(order, cancellationToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new Response<Guid>("The new order was successfully added", order.Id);
            
        }
    }
}
