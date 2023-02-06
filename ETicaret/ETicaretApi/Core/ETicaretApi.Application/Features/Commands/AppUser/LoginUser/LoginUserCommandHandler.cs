using E=ETicaretApi.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretApi.Application.Exceptions;
using ETicaretApi.Application.Abstaction.Token;
using ETicaretApi.Application.DTOs;
using ETicaretApi.Application.Services;

namespace ETicaretApi.Application.Features.Commands.AppUser.LoginUser
{
	public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
	{
		readonly IAuthService _authService;

		public LoginUserCommandHandler(IAuthService authService)
		{
			_authService = authService;
		}

		public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
		{
			var token = await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 15);
			return new LoginUserSuccessCommandResponse()
			{
				Token = token,
			};

			
		}
	}
}
