using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BeerTap.Model;
using BeerTap.Service.Services;
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
            throw new NotImplementedException();
        }
    }
}
