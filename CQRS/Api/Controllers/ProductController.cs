using Application.Command;
using Application.Models.RequestModel;
using Application.Models.ViewModel;
using Application.Query;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [EnableCors("myCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("{id}", Name = "id")]
        public async Task<ActionResult<ProductResponseModel>> GetProductbyId(int id)
        {
            return await _mediator.Send(new GetProductbyIdQuery(id));
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductResponseModel>>> GetAllProducts()
        {
            return await _mediator.Send(new GetAllProductQuery());
        }



        [HttpDelete("{id}",Name ="id")]
        public async Task<ActionResult<ProductResponseModel>> DeleteProductbyId(int id)
        {
            return await _mediator.Send(new DeleteProductByIdCommand(id));
        }


        [HttpPut("{id}", Name = "id")]
        public async Task<ActionResult<ProductResponseModel>> UpdateProductbyId(int id,UpdateProductModel updateProductModel)
        {
            return await _mediator.Send(new UpdateProductByCommand(id, updateProductModel.Price));
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponseModel>> AddProduct(AddProductRequestModel addProductRequestModel)
        {
            return await _mediator.Send(new AddProductCommand(addProductRequestModel.Name, addProductRequestModel.Price));
        }
    }
}
