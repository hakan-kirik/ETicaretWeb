using E=ETicaretApi.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretApi.Application.Abstaction.Token;
using Google.Apis.Auth;
using ETicaretApi.Application.DTOs;
using ETicaretApi.Application.Services;

namespace ETicaretApi.Application.Features.Commands.AppUser.GoogleLogin
{
	public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
	{
		readonly IAuthService _authService;

		public GoogleLoginCommandHandler(IAuthService authService)
		{
			_authService = authService;
		}

		public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
		{
			var token = await _authService.GoogleLoginAsync(request.IdToken, 15);
			
			return new()
			{
				Token = token
			};
		}
	}
}
