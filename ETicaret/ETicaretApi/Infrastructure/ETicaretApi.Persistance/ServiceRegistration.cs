using ETicaretApi.Application.Repositories.CustomerRepo;
using ETicaretApi.Application.Repositories.FileRepo;
using ETicaretApi.Application.Repositories.InvoiceFileRepo;
using ETicaretApi.Application.Repositories.OrderRepo;
using ETicaretApi.Application.Repositories.ProductImageFileRepo;
using ETicaretApi.Application.Repositories.ProductRepo;
using ETicaretApi.Persistance.Contexts;
using ETicaretApi.Persistance.Repositories.CustomerRepo;
using ETicaretApi.Persistance.Repositories.FileRepo;
using ETicaretApi.Persistance.Repositories.InvoiceFileRepo;
using ETicaretApi.Persistance.Repositories.OrderRepo;
using ETicaretApi.Persistance.Repositories.ProductImageFileRepo;
using ETicaretApi.Persistance.Repositories.ProductRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection service)
        {
            service.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            service.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            service.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            service.AddScoped<IOrderReadRepository, OrderReadRepository>();
            service.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            service.AddScoped<IProductReadRepository,ProductReadRepository>();
            service.AddScoped<IProductWriteRepository, ProductWriteRepository>();
			service.AddScoped<IFileReadRepository, FileReadRepository>();
			service.AddScoped<IFileWriteRepository, FileWriteRepository>();
			service.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
			service.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();
			service.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
			service.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();

		}

    }
}
