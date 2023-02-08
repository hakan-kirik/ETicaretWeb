using ETicaretApi.Application.DTOs.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Services.Configurations
{
	public interface IApplicationService
	{
		List<Menu> GetAuthorizeDefinationEndpoints(Type type);
	}
}
