using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BeerTap.ApiServices.Interface;
using BeerTap.Model;
using BeerTap.Service.Services;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices
{
    public class KegApiService : IKegApiService
    {
        private readonly KegService _kegService;

        public KegApiService()
        {
            _kegService = new KegService();
        }

        public Task<Keg> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context.UriParameters.GetByName<int>("OfficeId")
                .EnsureValueIsPresent(() => context.CreateHttpResponseException<Keg>("The Office Id must be supplied in the URI", HttpStatusCode.BadRequest));

            var keg = _kegService.GetKegByOfficeIdKegId(officeId, id);
            
            if (keg != null)
            {
                var resourceKeg = Mapper.Map<Keg>(keg);
                return Task.FromResult(resourceKeg);
            }

            throw context.CreateHttpResponseException<Keg>("The keg does not exist", HttpStatusCode.NotFound);
        }

        public Task<IEnumerable<Keg>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context.UriParameters.GetByName<int>("OfficeId")
                .EnsureValueIsPresent(() => context.CreateHttpResponseException<Keg>("The Office Id must be supplied in the URI", HttpStatusCode.BadRequest));

            var kegs = _kegService.GetKegsById(officeId);

            if (kegs.Any())
            {
                var resourceKegs = kegs.Select(keg => Mapper.Map<Keg>(keg)).ToList();
                return Task.FromResult(resourceKegs.AsEnumerable());
            }

            throw context.CreateHttpResponseException<Keg>("The kegs do not exist", HttpStatusCode.NotFound);
        }
    }
}
