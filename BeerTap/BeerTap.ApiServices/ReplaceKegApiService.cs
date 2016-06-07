using System.Net;
using System.Threading;
using System.Threading.Tasks;
using BeerTap.Model;
using BeerTap.Service.Services;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices
{
    public class ReplaceKegApiService : ICreateAResourceAsync<ReplaceKeg, int>
    {
        private KegService _kegService;

        public ReplaceKegApiService()
        {
            _kegService = new KegService();
        }
        public Task<ResourceCreationResult<ReplaceKeg, int>> CreateAsync(ReplaceKeg resource, IRequestContext context, CancellationToken cancellation)
        {
            var kegId = context.UriParameters.GetByName<int>("KegId")
                .EnsureValue(() => context.CreateHttpResponseException<ReplaceKeg>("The Keg Id must be supplied in the URI", HttpStatusCode.BadRequest));

            var officeId = context.UriParameters.GetByName<int>("OfficeId")
                .EnsureValue(() => context.CreateHttpResponseException<ReplaceKeg>("The Office Id must be supplied in the URI", HttpStatusCode.BadRequest));


            var keg = _kegService.GetKegByOfficeIdKegId(officeId, kegId);

            if (keg != null)
            {
                _kegService.ReplaceKeg(officeId, kegId);
                context.LinkParameters.Set(new LinksParametersSource(officeId, kegId));
                resource.Id = kegId;
                resource.OfficeId = officeId;

                return Task.FromResult(new ResourceCreationResult<ReplaceKeg, int>(resource));
            }

            throw context.CreateHttpResponseException<ReplaceKeg>("The keg does not exist", HttpStatusCode.NotFound);

        }
    }
}
