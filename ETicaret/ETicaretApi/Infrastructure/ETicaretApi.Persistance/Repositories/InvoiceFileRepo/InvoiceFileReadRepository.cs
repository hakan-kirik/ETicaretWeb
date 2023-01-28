using ETicaretApi.Application.Repositories.InvoiceFileRepo;
using ETicaretApi.Domain.Entities;
using ETicaretApi.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistance.Repositories.InvoiceFileRepo
{
	public class InvoiceFileReadRepository : ReadRepository<InvoiceFile>,IInvoiceFileReadRepository
	{
		public InvoiceFileReadRepository(ETicaretAPIDbContext context) : base(context)
		{
		}
	}
}
