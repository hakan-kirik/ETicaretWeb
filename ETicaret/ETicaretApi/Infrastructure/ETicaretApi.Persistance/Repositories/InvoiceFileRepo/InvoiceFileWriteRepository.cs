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
	public class InvoiceFileWriteRepository : WriteRepository<InvoiceFile>, IInvoiceFileWriteRepository
	{
		public InvoiceFileWriteRepository(ETicaretAPIDbContext context) : base(context)
		{
		}
	}
}
