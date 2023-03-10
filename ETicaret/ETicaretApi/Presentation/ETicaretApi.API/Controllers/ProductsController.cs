using ETicaretApi.Application.Abstaction.Storage;
using ETicaretApi.Application.Const;
using ETicaretApi.Application.CustomAttributes;
using ETicaretApi.Application.Enums;
using ETicaretApi.Application.Features.Commands.Product.CreateProduct;
using ETicaretApi.Application.Features.Commands.Product.RemoveProduct;
using ETicaretApi.Application.Features.Commands.Product.UpdateProduct;
using ETicaretApi.Application.Features.Commands.ProductImageFile.RemoveProductImage;
using ETicaretApi.Application.Features.Commands.ProductImageFile.UploadProductImage;
using ETicaretApi.Application.Features.Queries.Product.GetAllProduct;
using ETicaretApi.Application.Features.Queries.Product.GetProductById;
using ETicaretApi.Application.Features.Queries.ProductImageFile.GetProductImages;
using ETicaretApi.Application.Repositories.ProductImageFileRepo;
using ETicaretApi.Application.Repositories.ProductRepo;
using ETicaretApi.Application.RequestParameters;
using ETicaretApi.Application.Services;
using ETicaretApi.Application.ViewModels.Products;
using ETicaretApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ETicaretApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[Authorize(AuthenticationSchemes = "Admin")]
	public class ProductsController : ControllerBase
    {
    
        readonly IMediator _mediator;
		readonly ILogger<ProductsController> _logger;
		public ProductsController(ILogger<ProductsController> logger,
            IMediator mediator
            )
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [AuthorizeDefinition(Menu =AuthorizeDefinationConstans.Products,ActionType =Application.Enums.ActionType.Reading,Definition ="Delete Product")]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest pagination)
        {
            _logger.LogInformation("get all products");
            var response = await _mediator.Send(pagination);
            return Ok(response);

        }
        [HttpGet("{Id}")]
        [AuthorizeDefinition(Menu =AuthorizeDefinationConstans.Products,ActionType =ActionType.Reading,Definition ="Delete product by id")]
        public async Task<IActionResult> Get([FromRoute] GetProductByIdQueryRequest getProductById)
        {
            var response = await _mediator.Send(getProductById);


            return Ok(response);
        }

        [HttpPost]
        [AuthorizeDefinition(Menu =AuthorizeDefinationConstans.Products,ActionType =ActionType.Writing,Definition ="Create product")]
        public async Task<IActionResult> Post([FromBody]CreateProductCommandRequest model)
        {

            CreateProductCommandResponse respone = await _mediator.Send(model);
            return StatusCode((int)HttpStatusCode.Created);

        }

        [HttpPut]
        [AuthorizeDefinition(Menu =AuthorizeDefinationConstans.Products,ActionType =ActionType.Updating,Definition ="Update product")]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveProductCommandRequest removeProductCommand)
        {
            await _mediator.Send(removeProductCommand);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromQuery, FromForm] UploadProductImageCommandRequest uploadProductImage)
        {
            await _mediator.Send(uploadProductImage);

            return Ok();
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetProductImages([FromRoute] GetProductImagesQueryRequest getProductImagesId)
        {
            var results=await _mediator.Send(getProductImagesId);
            return Ok(results);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteProductImage([FromRoute]RemoveProductImageCommandRequest removeProductImage,[FromQuery]string ImageId)
        {
            removeProductImage.ImageId = ImageId;
            await _mediator.Send(removeProductImage);

            return Ok();
		}
    }
}
