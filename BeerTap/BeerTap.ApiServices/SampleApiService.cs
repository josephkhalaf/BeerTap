using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IQ.Platform.Framework.WebApi.Services.Security;
using BeerTap.ApiServices.Security;
using BeerTap.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices
{
    public class SampleApiService : ISampleApiService
    {

        readonly IApiUserProvider<BeerTapApiUser> _userProvider;

        public SampleApiService(IApiUserProvider<BeerTapApiUser> userProvider)
        {
            if (userProvider == null)
                throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;
        }


        public Task<SampleResource> GetAsync(string id, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SampleResource>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ResourceCreationResult<SampleResource, string>> CreateAsync(SampleResource resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<SampleResource> UpdateAsync(SampleResource resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ResourceOrIdentifier<SampleResource, string> input, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
