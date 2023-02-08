using ETicaretApi.Application.Services.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApplicationServicesController : ControllerBase
	{
		readonly IApplicationService _applicationService;
		public ApplicationServicesController(IApplicationService applicationService)
		{
			_applicationService = applicationService;
		}

		[HttpGet]
		public IActionResult GetAuthorizeDefinitionEndpoints()
		{
			var datas = _applicationService.GetAuthorizeDefinationEndpoints(typeof(Program));
			return Ok(datas);
		}
	}
}
