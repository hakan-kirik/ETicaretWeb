using ETicaretApi.Application.Repositories.ProductImageFileRepo;
using ETicaretApi.Application.Repositories.ProductRepo;
using ETicaretApi.Domain.Entities;
using ETicaretApi.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistance.Repositories.ProductImageFileRepo
{
	public class ProductImageFileReadRepository : ReadRepository<ProductImageFile>, IProductImageFileReadRepository
	{
		public ProductImageFileReadRepository(ETicaretAPIDbContext context) : base(context)
		{
		}
	}
}
