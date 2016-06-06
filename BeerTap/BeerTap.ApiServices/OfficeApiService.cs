using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BeerTap.ApiServices.Interface;
using BeerTap.Model;
using BeerTap.Service.Services;
using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices
{
    public class OfficeApiService : IOfficeApiService
    {
        private readonly OfficeService _officeService;

        public OfficeApiService()
        {
            _officeService = new OfficeService();
        }

        public Task<Office> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var office = _officeService.Get(id);
            var resourceOffice = Mapper.Map<Office>(office);
            if (office != null)
            {
                return Task.FromResult(resourceOffice);
            }

            throw context.CreateHttpResponseException<Office>($"The office does not exist", HttpStatusCode.NotFound);
        }

        public Task<IEnumerable<Office>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            var offices = _officeService.GetAll();

            if(offices.Any())
            { 
                var resourceOffice = offices.Select(office => Mapper.Map<Office>(office)).ToList();
                return Task.FromResult(resourceOffice.AsEnumerable());

            }
            throw context.CreateHttpResponseException<Office>($"The offices do not exist", HttpStatusCode.NotFound);
        }
    }
}
