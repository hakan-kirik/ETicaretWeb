using  N=ETicaretApi.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretApi.Application.Services;
using ETicaretApi.Application.DTOs;

namespace ETicaretApi.Application.Features.Commands.AppUser.CreateUser
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
	{
		readonly IUserService _userService;

		public CreateUserCommandHandler(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
		{
			CreateUserResponse response=await _userService.CreateAsync(new()
			{
				Email= request.Email,
				NameSurname= request.NameSurname,
				Password= request.Password,
				PasswordConfirm= request.PasswordConfirm,
				Username= request.Username,
			});
			return new()
			{
				Message = response.Message,
				Succeeded = response.Succeeded,
			};

		}
	}
}
