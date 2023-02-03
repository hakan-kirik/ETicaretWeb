using ETicaretApi.Application.DTOs;
using ETicaretApi.Application.Services;
using ETicaretApi.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Apis.Requests.BatchRequest;

namespace ETicaretApi.Persistance.Services
{
	public class UserService : IUserService
	{
		readonly UserManager<AppUser> _userManager;

		public UserService(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}


		public async Task<CreateUserResponse> CreateAsync(CreateUser model)
		{
			IdentityResult result= await _userManager.CreateAsync(new()
			{
				Id=Guid.NewGuid().ToString(),
				UserName=model.Username,
				Email=model.Email,
				NameSurname=model.NameSurname,
				
			},model.Password);

			CreateUserResponse response = new CreateUserResponse()
			{
				Succeeded=result.Succeeded,
			};
			if(result.Succeeded)
				response.Message = "Kullanıcı başarıyla oluşturulmuştur.";
			else
				foreach (var error in result.Errors)
					response.Message += $"{error.Code} - {error.Description}\n";

			return response;
		}
	}
}
