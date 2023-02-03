using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Services.Authentications
{
	public interface IInternalAuthentication
	{
		Task<DTOs.Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);
	}
}
