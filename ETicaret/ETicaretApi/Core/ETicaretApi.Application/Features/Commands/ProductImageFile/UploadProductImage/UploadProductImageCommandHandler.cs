using ETicaretApi.Application.Abstaction.Storage;
using ETicaretApi.Application.Repositories.ProductImageFileRepo;
using ETicaretApi.Application.Repositories.ProductRepo;
using MediatR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Commands.ProductImageFile.UploadProductImage
{
	public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommandRequest, UploadProductImageCommandResponse>
	{
		readonly IStorageService _storageService;
		readonly IProductReadRepository _productReadRepository;
		readonly IProductImageFileWriteRepository _productImageFileWriteRepository;

		public UploadProductImageCommandHandler(IStorageService storageService, IProductReadRepository productReadRepository, IProductImageFileWriteRepository productImageFileWriteRepository)
		{
			_storageService = storageService;
			_productReadRepository = productReadRepository;
			_productImageFileWriteRepository = productImageFileWriteRepository;
		}

		public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
		{
			List<(string fileName, string pathOrContainerName)> results = await _storageService.UploadAsync("productimage", request.Files);

			var product = await _productReadRepository.GetByIdAsync(request.Id);

			await _productImageFileWriteRepository.AddRangeAsync(results.Select(r => new Domain.Entities.ProductImageFile
			{
				FileName = r.fileName,
				Path = r.pathOrContainerName,
				Storage = _storageService.StorageName,
				Products = new List<Domain.Entities.Product>() { product }
			}).ToList());

			await _productImageFileWriteRepository.SaveAsync();
			return new();
		}
	}
}
