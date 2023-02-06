using ETicaretApi.Application.DTOs;
using ETicaretApi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Services
{
	public interface IUserService
	{
		Task<CreateUserResponse> CreateAsync(CreateUser model);
		Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
	}
}
