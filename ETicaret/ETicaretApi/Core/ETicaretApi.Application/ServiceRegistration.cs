using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application
{
	public static class ServiceRegistration
	{
		public static void AddApplicationServices(this IServiceCollection service)
		{
			service.AddMediatR(typeof(ServiceRegistration));
		}
	}
}
