namespace Application.Common.Interfaces
{
    public interface INotificationApplicationHubService
    {

        Task SendApplication(string message, CancellationToken cancellationToken);
    }
}
