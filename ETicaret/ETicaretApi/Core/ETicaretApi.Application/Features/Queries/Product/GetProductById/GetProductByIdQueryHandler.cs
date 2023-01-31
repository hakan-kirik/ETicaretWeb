using ETicaretApi.Application.Repositories.ProductRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Queries.Product.GetProductById
{
	public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
	{
		IProductReadRepository _productReadRepository;
		public GetProductByIdQueryHandler(IProductReadRepository productReadRepository)
		{
			_productReadRepository = productReadRepository;
		}
		
		public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
		{
			var response=await _productReadRepository.GetByIdAsync(request.Id);

			return new()
			{
				Name = response.Name,
				Price = response.Price,
				Stock = response.Stock,
			};
		}
	}
}
