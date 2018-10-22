using System.Threading.Tasks;
using CashFlux.Web.Features.Profile;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CashFlux.Web.Controllers
{
	public class ProfileController : CashFluxControllerBase
	{
		public ProfileController(IMediator mediator) : base(mediator) { }

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(string id)
		{
			return await HandleRequestAsync(new ProfileGetRequest {Id = id});
		}

		[HttpGet("byuserid/{id}")]
		public async Task<IActionResult> GetByUserId(string id)
		{
			return await HandleRequestAsync(new ProfileGetByUserIdRequest {Id = id});
		}

		[HttpGet("byusername/{username}")]
		public async Task<IActionResult> GetByUsername(string username)
		{
			return await HandleRequestAsync(new ProfileGetByUsernameRequest{Username = username});
		}
		
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] ProfilePostRequestModel model)
		{
			return await HandleRequestAsync(new ProfileCreateRequest {Model = model});
		}
	}
}