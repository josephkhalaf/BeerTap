using System.Net;
using System.Threading;
using System.Threading.Tasks;
using BeerTap.Model;
using BeerTap.Service.Services;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices
{
    public class AddKegApiService : ICreateAResourceAsync<AddKeg, int>
    {
        private readonly KegService _kegService;
        private readonly OfficeService _officeService;


        public AddKegApiService()
        {
            _kegService = new KegService();
            _officeService = new OfficeService();
        }

        public Task<ResourceCreationResult<AddKeg, int>> CreateAsync(AddKeg resource, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context.UriParameters.GetByName<int>("OfficeId")
                .EnsureValue(() => context.CreateHttpResponseException<AddKeg>("The Office Id must be supplied in the URI", HttpStatusCode.BadRequest));

            var office = _officeService.Get(officeId);
            if (office != null)
            {
                var newKegId = _kegService.AddKeg(officeId);

                context.LinkParameters.Set(new LinksParametersSource(officeId, newKegId));
                resource.OfficeId = officeId;
                resource.Id = newKegId;

                return Task.FromResult(new ResourceCreationResult<AddKeg, int>(resource));
            }

            throw context.CreateHttpResponseException<AddKeg>("The office does not exist", HttpStatusCode.NotFound);        
        }
    }
}
