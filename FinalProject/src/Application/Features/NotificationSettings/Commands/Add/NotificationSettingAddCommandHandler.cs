using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;

namespace Application.Features.NotificationSettings.Commands.Add
{
    public class NotificationSettingAddCommandHandler : IRequestHandler<NotificationSettingAddCommand, Response<Guid>>
    {

        private readonly IApplicationDbContext _applicationDbContext;

        public NotificationSettingAddCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Response<Guid>> Handle(NotificationSettingAddCommand request, CancellationToken cancellationToken)
        {
            var notificationSetting = new NotificationSetting()
            {
                Id = Guid.NewGuid(),
                IsApplicationEnabled = request.IsApplicationEnabled,
                IsEmailEnabled = request.IsEmailEnabled,
                EmailAddress = request.EmailAddress,
                UserName = request.UserName,
                CreatedOn = DateTimeOffset.Now,
                CreatedByUserId = null,
                IsDeleted = false,
            };


            var existedSetting = await _applicationDbContext.NotificationSettings.FirstOrDefaultAsync();


            if (existedSetting == null) await _applicationDbContext.NotificationSettings.AddAsync(notificationSetting, cancellationToken);
            else
            {

                existedSetting.IsApplicationEnabled = request.IsEmailEnabled;
                existedSetting.EmailAddress = request.EmailAddress;
                existedSetting.UserName = request.UserName;
                existedSetting.IsEmailEnabled = request.IsEmailEnabled;


                _applicationDbContext.NotificationSettings.Update(existedSetting);

            }

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new Response<Guid>("Notificationsetting is added.", notificationSetting.Id);

        }
    }
}
