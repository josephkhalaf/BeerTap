using System.Net;
using System.Threading;
using System.Threading.Tasks;
using BeerTap.Model;
using BeerTap.Service.Services;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices
{
    public class GetBeerApiService : ICreateAResourceAsync<GetBeer, int>
    {
        private KegService _kegService;

        public GetBeerApiService()
        {
            _kegService = new KegService();
        }

        public Task<ResourceCreationResult<GetBeer, int>> CreateAsync(GetBeer resource, IRequestContext context, CancellationToken cancellation)
        {
            var kegId = context.UriParameters.GetByName<int>("KegId")
                .EnsureValue(() => context.CreateHttpResponseException<Keg>("The Keg Id must be supplied in the URI", HttpStatusCode.BadRequest));

            var officeId = context.UriParameters.GetByName<int>("OfficeId")
                .EnsureValue(() => context.CreateHttpResponseException<Keg>("The Office Id must be supplied in the URI", HttpStatusCode.BadRequest));


            int size = resource.Size;

            context.LinkParameters.Set(new LinksParametersSource(officeId, kegId));

            _kegService.GetBeer(officeId, kegId, size);

            resource.Id = kegId;
            resource.OfficeId = officeId;
            return Task.FromResult(new ResourceCreationResult<GetBeer, int>(resource));
        }
    }
}