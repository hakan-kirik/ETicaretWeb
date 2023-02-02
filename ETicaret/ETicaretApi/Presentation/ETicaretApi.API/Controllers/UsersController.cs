using ETicaretApi.Application.Features.Commands.AppUser.CreateUser;
using ETicaretApi.Application.Features.Commands.AppUser.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		readonly IMediator _mediator;

		public UsersController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
		{
			CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
			return Ok(response);
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> Login(LoginUserCommandRequest login)
		{
			LoginUserCommandResponse response=await	_mediator.Send(login);


			return Ok(response);
		}
	}
}
