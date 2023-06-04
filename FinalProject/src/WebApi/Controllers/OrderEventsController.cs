using Application.Features.OrderEvents.Queries.GetAll;
using Application.Features.OrdersStatus.Commands.Add;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
  
    public class OrderEventsController :ApiControllerBase
    {
        [HttpPost("Add")]
        public async Task<IActionResult> AddOrderEventAsync(OrderEventAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("GetAllByOrderId")]
        public async Task<IActionResult> GetAllByOrderIdAsync(OrderEventsGetAllByOrderIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var query= new OrderEventsGetAllQuery();
            return Ok(await Mediator.Send(query));
        }

    }
}
