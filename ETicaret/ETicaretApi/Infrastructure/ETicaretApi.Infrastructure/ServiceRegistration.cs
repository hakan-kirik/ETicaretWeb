using ETicaretApi.Application.Services;
using ETicaretApi.Infrastructure.Services;
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
		}

	}
}
