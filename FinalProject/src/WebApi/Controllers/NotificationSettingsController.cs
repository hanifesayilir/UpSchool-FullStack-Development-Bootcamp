using Application.Features.NotificationSettings.Commands.Add;
using Application.Features.NotificationSettings.Query.GetIfExist;
using Application.Features.OrderEvents.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class NotificationSettingsController : ApiControllerBase
    {
        [HttpPost("Add")]
        public async Task<IActionResult> AddNotificationSettingAsync(NotificationSettingAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("GetIfAny")]
        public async Task<IActionResult> GetNotificationSettingAsync()
        {
            var query = new NotificationSettingGetIfAnyQuery();
            return Ok(await Mediator.Send(query));
       
        }

    }
}
