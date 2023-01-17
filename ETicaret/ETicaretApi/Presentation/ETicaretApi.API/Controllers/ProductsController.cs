using ETicaretApi.Application.Repositories.ProductRepo;
using ETicaretApi.Application.RequestParameters;
using ETicaretApi.Application.ViewModels.Products;
using ETicaretApi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductReadRepository _productReadRepository;
        readonly private IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Pagination pagination)
        {
            int totalCount = _productReadRepository.GetAll(false).Count();   
            var products = _productReadRepository.GetAll(false).Skip(pagination.Page*pagination.Size).Take(pagination.Size).Select(
               p => new
               {
                   p.Id,
                   p.Name,
                   p.Price,
                   p.Stock,
                   p.CreatedDate,
                   p.UpdatedDate
               });
			return Ok(new
            {
                totalCount,
                products
            });

			//var count = await _productWriteRepository.AddAsync(new()
			//{
			//    Id = Guid.NewGuid(),
			//    Name = "product",
			//    Price = 23.4F,
			//    Stock = 23
			//});
			// var product= await _productReadRepository.GetByIdAsync("69a332c9-465e-4876-8385-32946c9040d1");
			//  product.Name = "hakanss";
			// await _productWriteRepository.SaveAsync();
		}
		[HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
           var product= await _productReadRepository.GetByIdAsync(id, false);


			return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            if (ModelState.IsValid) { }

          await  _productWriteRepository.AddAsync(new()
            {
                Name=model.Name,
                Price=model.Price,
                Stock=model.Stock
            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);

        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product=await _productReadRepository.GetByIdAsync(model.Id);
            product.Stock = model.Stock;
            product.Name = model.Name;
            product.Price = model.Price;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
