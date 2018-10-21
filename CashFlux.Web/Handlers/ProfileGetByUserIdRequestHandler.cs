using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CashFlux.Data;
using CashFlux.Web.Models.Profile;
using CashFlux.Web.Requests;

namespace CashFlux.Web.Handlers
{
	public class ProfileGetByUserIdRequestHandler
		: CashFluxProfileRequestHandler<ProfileGetByUserIdRequest, List<ProfileGetRequestModel>>
	{
		public ProfileGetByUserIdRequestHandler(CashFluxDbContext context, IMapper mapper)
			: base(context, mapper) { }

		public override async Task<List<ProfileGetRequestModel>> Handle(ProfileGetByUserIdRequest request,
			CancellationToken cancellationToken)
		{
			var profiles = await GetProfilesByUserIdAsync(request.Id, cancellationToken);
			return Mapper.Map<List<ProfileGetRequestModel>>(profiles);
		}
	}
}