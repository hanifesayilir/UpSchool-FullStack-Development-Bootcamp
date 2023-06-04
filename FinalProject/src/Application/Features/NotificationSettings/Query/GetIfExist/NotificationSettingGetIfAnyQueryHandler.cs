using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NotificationSettings.Query.GetIfExist
{
    public class NotificationSettingGetIfAnyQueryHandler : IRequestHandler<NotificationSettingGetIfAnyQuery, NotificationSetting>
    {

        private readonly IApplicationDbContext _applicationDbContext;

        public NotificationSettingGetIfAnyQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext= applicationDbContext;
        }
        public  Task<NotificationSetting> Handle(NotificationSettingGetIfAnyQuery request, CancellationToken cancellationToken)
        {
           var existingNotification = _applicationDbContext.NotificationSettings.FirstOrDefault();
             return Task.FromResult(existingNotification);
         
        }
    }
}
