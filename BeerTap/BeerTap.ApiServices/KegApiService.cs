using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
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
        private KegService _kegService;

        public KegApiService()
        {
            _kegService = new KegService();
        }

        public Task<Keg> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var officeId =
                context.UriParameters.GetByName<string>("OfficeId")
                    .EnsureValueIsPresent(() =>
                            context.CreateHttpResponseException<Keg>("The personID must be supplied in the URI",
                                HttpStatusCode.BadRequest));
            var keg = _kegService.Get(id);
            var resourceKeg = Mapper.Map<Keg>(keg);
            if (keg != null)
            {
                return Task.FromResult(resourceKeg);
            }

            throw context.CreateHttpResponseException<Office>($"The keg does not exist", HttpStatusCode.NotFound);
        }

        public Task<IEnumerable<Keg>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
