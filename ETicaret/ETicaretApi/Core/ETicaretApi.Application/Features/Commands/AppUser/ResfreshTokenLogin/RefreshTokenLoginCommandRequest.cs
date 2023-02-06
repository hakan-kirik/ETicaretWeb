using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Commands.AppUser.ResfreshTokenLogin
{
	public class RefreshTokenLoginCommandRequest:IRequest<RefreshTokenLoginCommandResponse>
	{
		public string RefreshToken { get; set; }
	}
}
