using eShopFeriaVirtual.Application.Features.Products.Commands.CreateProduct;
using eShopFeriaVirtual.Application.Features.Products.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopFeriaVirtual.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(200)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _mediator.Send(new GetProductByIdRequest() { Id = id });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateProductRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok();
        }

    }
}
