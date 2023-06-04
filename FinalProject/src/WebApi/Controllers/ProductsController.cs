using Application.Features.Products.Commands.Add;
using Application.Features.Products.Commands.AddList;
using Application.Features.Products.Queries.GetAll;
using Application.Features.Products.Queries.GetAllByOrderId;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    public class ProductsController : ApiControllerBase
    {

       [HttpPost("Add")]
        public async Task<IActionResult> AddProductAsync(ProductAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpPost("AddList")]
        public async Task<IActionResult> AddProductListAsync(ProductListAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("GetByOrderId")]
        public async Task<IActionResult> GetProductsByOrderIdAsync(ProductGetByOrderIdQueryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            return Ok(await Mediator.Send(new ProductGetAllQuery()));
        }
    }
}
