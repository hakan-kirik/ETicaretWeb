using ETicaretApi.Application.Repositories.FileRepo;
using ETicaretApi.Domain.Entities;
using ETicaretApi.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistance.Repositories.FileRepo
{
	public class FileWriteRepository : WriteRepository<FileBase>,IFileWriteRepository
	{
		public FileWriteRepository(ETicaretAPIDbContext context) : base(context)
		{
		}
	}
}
