using ETicaretApi.Application.Abstaction.Hubs;
using ETicaretApi.Application.Repositories.ProductRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Commands.Product.CreateProduct
{
	public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
	{
		readonly IProductWriteRepository _productWriteRepository;
		readonly IProductHubService _productHubService;
		public CreateProductCommandHandler(IProductWriteRepository productWriteRepository,IProductHubService productHub)
		{
			_productHubService= productHub;
			_productWriteRepository = productWriteRepository;
		}

		
		public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
		{
			await _productWriteRepository.AddAsync(new()
			{
				Name = request.Name,
				Price = request.Price,
				Stock = request.Stock,
			});
			await _productWriteRepository.SaveAsync();
			await _productHubService.ProductAddedMessageAsync($"{request.Name} adli urun eklenmistir");
			return new();
		}
	}
}
