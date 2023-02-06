using DTO=ETicaretApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Abstaction.Token
{
	public interface ITokenHandler
	{
		DTO.Token CreateAccessToken(int minute);
		string CreateRefreshToken();
	}
}
