using System.Threading;
using System.Threading.Tasks;
using BeerTap.Model;
using BeerTap.Service.Services;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices
{
    public class GetBeerApiService :/* IUpdateAResourceAsync<GetBeer, int>,*/ ICreateAResourceAsync<GetBeer, int>
    {
        private readonly KegService _kegService;

        public GetBeerApiService()
        {
            _kegService = new KegService();
        }

        //public Task<GetBeer> UpdateAsync(GetBeer resource, IRequestContext context, CancellationToken cancellation)
        //{
        //    //var officeId = context.UriParameters.GetByName<string>("OfficeId").EnsureValueIsPresent(() => context.CreateHttpResponseException<Keg>("The office id must be supplied in the URI", HttpStatusCode.BadRequest));

        //    var officeId = context.UriParameters.GetByName<int>("OfficeId").EnsureValue();
        //    var uri = context.UriParameters;
        //    int kegId = resource.Id;
        //    int size = resource.Size;

        //    //_kegService.GetBeer(officeId, kegId, size);

        //    return Task.FromResult(resource);
        //}

        public Task<ResourceCreationResult<GetBeer, int>> CreateAsync(GetBeer resource, IRequestContext context, CancellationToken cancellation)
        {
            //context.LinkParameters.Set(new LinksParametersSource());
            var officeId = context.UriParameters.GetByName<int>("OfficeId").EnsureValue();
            var uri = context.UriParameters;
            int kegId = resource.Id;
            int size = resource.Size;

            return Task.FromResult(new ResourceCreationResult<GetBeer, int>(resource));
        }
    }
}
