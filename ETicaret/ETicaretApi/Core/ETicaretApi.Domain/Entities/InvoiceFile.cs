using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Domain.Entities
{
	public class InvoiceFile:FileBase
	{
		public decimal Price { get; set; }

	}
}
