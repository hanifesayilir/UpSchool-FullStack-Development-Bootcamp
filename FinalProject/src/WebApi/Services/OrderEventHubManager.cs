using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.SignalR;
using WebApi.Hubs;

namespace WebApi.Services
{
    public class OrderEventHubManager : IOrderEventHubService
    {
        private readonly IHubContext<OrderEventHub> _hubContext;

        public OrderEventHubManager(IHubContext<OrderEventHub> hubContext)
        {
            _hubContext = hubContext;
        }
   
        public  async Task AddedAsync(OrderEvent orderEvent, CancellationToken cancellationToken)
        {
             await _hubContext.Clients.All.SendAsync("Added", orderEvent, cancellationToken);
            
        }
    }
}
