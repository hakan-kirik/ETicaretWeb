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

namespace ETicaretApi.Application.Features.Commands.AppUser.LoginUser
{
	public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
	{
		readonly UserManager<E.AppUser> userManager;
		readonly SignInManager<E.AppUser> signInManager;
		readonly ITokenHandler tokenHandler;

		public LoginUserCommandHandler(UserManager<E.AppUser> userManager, 
			SignInManager<E.AppUser> signInManager,
			ITokenHandler tokenHandler
			)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.tokenHandler= tokenHandler;
		}

		public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
		{
			E.AppUser user = await userManager.FindByEmailAsync(request.UsernameOrEmail);
			if (user == null)
			{
				user=await userManager.FindByNameAsync(request.UsernameOrEmail);
			}
			if(user == null)
			{
				throw new NotFoundUserException();
			}
			SignInResult result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);
			if(result.Succeeded)
			{
				Token token = tokenHandler.CreateAccessToken(5);
				return new LoginUserSuccessCommandResponse()
				{
					Token = token,
				};

			}

			throw new AuthenticationErrorException();
		}
	}
}
