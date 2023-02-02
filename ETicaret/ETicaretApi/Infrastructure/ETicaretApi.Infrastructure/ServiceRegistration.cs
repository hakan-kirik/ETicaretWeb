using ETicaretApi.Application.Abstaction.Storage;
using ETicaretApi.Application.Abstaction.Token;
using ETicaretApi.Application.Services;
using ETicaretApi.Infrastructure.Services;
using ETicaretApi.Infrastructure.Services.Storage;
using ETicaretApi.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Infrastructure
{
	public static class ServiceRegistration
	{
		public static void AddInfastructureServices(this IServiceCollection service) {
			service.AddScoped<IFileService,FileService>();
			service.AddScoped<IStorageService, StorageService>();
			service.AddScoped<ITokenHandler,TokenHandler>();
		}
		public static void  AddStorage<T>(this IServiceCollection service)where T: Storage, IStorage 
		{
			service.AddScoped<IStorage,T>();
		}

	}
}
