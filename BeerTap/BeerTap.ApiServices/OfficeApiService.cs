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
using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices
{
    public class OfficeApiService : IOfficeApiService
    {
        private OfficeService _officeService;

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
            else
            {
                throw context.CreateHttpResponseException<Office>($"The office does not exist", HttpStatusCode.NotFound);
            }
        }

        public Task<IEnumerable<Office>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            var offices = _officeService.GetAll();

            var resourceOffice = offices.Select(office => Mapper.Map<Office>(office)).ToList();


            return Task.FromResult(resourceOffice.AsEnumerable());
        }

        public Task<ResourceCreationResult<Office, int>> CreateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
