using ETicaretApi.Application.Repositories.ProductRepo;
using ETicaretApi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task Get()
        {
            //var count = await _productWriteRepository.AddAsync(new()
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "product",
            //    Price = 23.4F,
            //    Stock = 23
            //});
          var product= await _productReadRepository.GetByIdAsync("69a332c9-465e-4876-8385-32946c9040d1");
            product.Name = "hakanss";
            await _productWriteRepository.SaveAsync();
        }

    }
}
