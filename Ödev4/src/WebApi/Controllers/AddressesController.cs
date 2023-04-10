using Application.Features.Addresses.Commands.Add;
using Application.Features.Addresses.Commands.Delete;
using Application.Features.Addresses.Commands.SoftDelete;
using Application.Features.Addresses.Commands.Update;
using Application.Features.Addresses.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    public class AddressesController : ApiControllerBase
    {
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(AddressAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync(AddressUpdateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpPost("HardDelete")]
        public async Task<IActionResult> HardDeleteAsync(AddressDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> SofDeleteAsync(AddressSoftDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllAsync(AddressGetAllQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        /*  [HttpGet("{userId}/{id}")]
          public async Task<IActionResult> GetByIdAsync(int userId,int id)
          {
              return Ok(await Mediator.Send(new AddressGetByIdQuery(userId,id, null)));
          }*/

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await Mediator.Send(new AddressGetAllQuery(id,null)));
        }




    }
}
