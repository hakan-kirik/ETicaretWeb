using ETicaretApi.Application.Abstaction.Token;
using Dto=ETicaretApi.Application.DTOs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ETicaretApi.Domain.Entities.Identity;
using System.Security.Claims;

namespace ETicaretApi.Infrastructure.Services.Token
{
	public class TokenHandler:ITokenHandler
	{
		IConfiguration configuration;

		public TokenHandler(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

	

		public Application.DTOs.Token CreateAccessToken(int second,AppUser appUser)
		{
			Dto.Token token = new();

			SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]));

			SigningCredentials signingCredential = new(securityKey, SecurityAlgorithms.HmacSha256);

			token.Expiration=DateTime.UtcNow.AddSeconds(second);

			JwtSecurityToken securityToken = new(
				audience: configuration["Token:Audience"],
				issuer: configuration["Token:Issuer"],
				notBefore:DateTime.UtcNow,
				expires: token.Expiration,
				signingCredentials:signingCredential,
				claims:new List<Claim> { new (ClaimTypes.Name,appUser.UserName)}
				
				);

			JwtSecurityTokenHandler tokenHandler= new();
			token.AccessToken=tokenHandler.WriteToken(securityToken);
			token.RefreshToken = CreateRefreshToken();
			return token;

		}
		public string CreateRefreshToken()
		{
			byte[] number = new byte[32];
			using RandomNumberGenerator random = RandomNumberGenerator.Create();
			random.GetBytes(number);
			return Convert.ToBase64String(number);
		}
	}
}
