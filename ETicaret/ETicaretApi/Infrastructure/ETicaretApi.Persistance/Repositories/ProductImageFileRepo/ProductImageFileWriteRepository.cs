using ETicaretApi.Application.Repositories.ProductImageFileRepo;
using ETicaretApi.Domain.Entities;
using ETicaretApi.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistance.Repositories.ProductImageFileRepo
{
	public class ProductImageFileWriteRepository : WriteRepository<ProductImageFile>, IProductImageFileWriteRepository
	{
		public ProductImageFileWriteRepository(ETicaretAPIDbContext context) : base(context)
		{
		}
	}
}
