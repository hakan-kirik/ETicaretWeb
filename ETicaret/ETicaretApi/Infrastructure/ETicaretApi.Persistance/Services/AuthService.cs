using ETicaretApi.Application.Abstaction.Token;
using ETicaretApi.Application.DTOs;
using ETicaretApi.Application.Exceptions;
using ETicaretApi.Application.Services;
using ETicaretApi.Domain.Entities.Identity;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistance.Services
{
	public class AuthService : IAuthService
	{
		readonly IConfiguration _configuration;
		readonly UserManager<AppUser> _userManager;
		readonly ITokenHandler _tokenHandler;
		readonly SignInManager<AppUser> _signInManager;

		public AuthService(IConfiguration configuration, UserManager<AppUser> userManager,ITokenHandler tokenHandler,SignInManager<AppUser> signInManager)
		{
			_configuration = configuration;
			_userManager = userManager;
			_tokenHandler = tokenHandler;
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public async  Task<Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime)
		{

			var settings = new GoogleJsonWebSignature.ValidationSettings()
			{
				Audience = new List<string> { _configuration["ExternalLoginSettings:Google:Client_ID"] }
			};

			var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);

			var info = new UserLoginInfo("GOOGLE", payload.Subject, "GOOGLE");
			AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

			return await CreateUserExternalAsync(user, payload.Email, payload.Name, info, accessTokenLifeTime);
		}

		public async Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
		{
			AppUser user = await _userManager.FindByNameAsync(usernameOrEmail);
			if (user == null)
				user = await _userManager.FindByEmailAsync(usernameOrEmail);

			if (user == null)
				throw new NotFoundUserException();

			SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
			if (result.Succeeded) //Authentication başarılı!
			{
				Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime);
				return token;
			}
			throw new AuthenticationErrorException();
		}


		async Task<Token> CreateUserExternalAsync(AppUser user, string email, string name, UserLoginInfo info, int accessTokenLifeTime)
		{
			bool result = user != null;
			if (user == null)
			{
				user = await _userManager.FindByEmailAsync(email);
				if (user == null)
				{
					user = new()
					{
						Id = Guid.NewGuid().ToString(),
						Email = email,
						UserName = email,
						NameSurname = name
					};
					var identityResult = await _userManager.CreateAsync(user);
					result = identityResult.Succeeded;
				}
			}

			if (result)
			{
				await _userManager.AddLoginAsync(user, info); //AspNetUserLogins

				Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime);
				return token;
			}
			throw new Exception("Invalid external authentication.");
		}
	}
}
