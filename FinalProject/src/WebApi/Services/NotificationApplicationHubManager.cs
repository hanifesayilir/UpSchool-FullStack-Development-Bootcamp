using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using WebApi.Hubs;

namespace WebApi.Services
{
    public class NotificationApplicationHubManager : INotificationApplicationHubService
    {

        private readonly IHubContext<NotificationApplicationHub>  _hubContext;

        public NotificationApplicationHubManager(IHubContext<NotificationApplicationHub> hubContext)
        {
            _hubContext= hubContext;
        }
        public async Task SendApplication(string message, CancellationToken cancellationToken)
        {
            await _hubContext.Clients.All.SendAsync("SendApplicationNotifications", message, cancellationToken);
        }
    }
}
