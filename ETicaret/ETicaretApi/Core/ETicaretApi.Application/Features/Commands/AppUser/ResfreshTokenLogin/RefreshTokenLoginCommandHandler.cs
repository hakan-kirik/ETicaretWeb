using ETicaretApi.Application.DTOs;
using ETicaretApi.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Commands.AppUser.ResfreshTokenLogin
{
	public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, RefreshTokenLoginCommandResponse>
	{
		readonly IAuthService _authService;
		public RefreshTokenLoginCommandHandler(IAuthService authService)
		{
			_authService = authService;
		}
		public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
		{
			Token token = await _authService.RefreshTokenLoginAsync(request.RefreshToken);
			return new()
			{
				Token = token
			};
		}
	}
}
