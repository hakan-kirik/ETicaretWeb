using ETicaretApi.Application.Services.Authentications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Services
{
	public interface IAuthService:IExternalAuthentication,IInternalAuthentication
	{
		
	}
}
