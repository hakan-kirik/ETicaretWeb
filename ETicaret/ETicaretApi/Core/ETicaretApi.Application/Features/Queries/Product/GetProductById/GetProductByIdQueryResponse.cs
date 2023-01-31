using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Queries.Product.GetProductById
{
	public class GetProductByIdQueryResponse
	{
		public string  Name { get; set; }
		public float Price { get; set; }
		public int Stock { get; set; }

	}
}
