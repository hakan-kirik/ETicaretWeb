using DTO=ETicaretApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretApi.Domain.Entities.Identity;

namespace ETicaretApi.Application.Abstaction.Token
{
	public interface ITokenHandler
	{
		DTO.Token CreateAccessToken(int second,AppUser appUser);
		string CreateRefreshToken();
	}
}
