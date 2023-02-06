using ETicaretApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Commands.AppUser.ResfreshTokenLogin
{
	public class RefreshTokenLoginCommandResponse
	{
		public Token Token { get; set; }
	}
}
