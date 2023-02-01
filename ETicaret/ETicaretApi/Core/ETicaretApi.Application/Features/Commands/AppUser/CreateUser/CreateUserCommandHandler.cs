using  N=ETicaretApi.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Commands.AppUser.CreateUser
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
	{
		readonly UserManager<N.AppUser> userManager;

		public CreateUserCommandHandler(UserManager<N.AppUser> userManager)
		{
			this.userManager = userManager;
		}

		public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
		{

			IdentityResult result= await userManager.CreateAsync(new()
			{
				Id = Guid.NewGuid().ToString(),
				UserName = request.Username,
				Email = request.Email,
				NameSurname = request.NameSurname,
			}, request.Password);

			CreateUserCommandResponse response = new() { Succeeded = result.Succeeded };
			if (result.Succeeded)
			{
				response.Message = "kullanici kayit edildi";
			}
			else
			{
				foreach(var error in result.Errors)
				{
					response.Message += $"{error.Code}-{error.Description}\n";
				}
				
			}
			return response;
		}
	}
}
