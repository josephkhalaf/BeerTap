﻿using System.Net;
using System.Threading;
using System.Threading.Tasks;
using BeerTap.Model;
using BeerTap.Service.Constant;
using BeerTap.Service.Services;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices
{
    public class AddKegApiService : ICreateAResourceAsync<AddKeg, int>
    {
        private KegService _kegService;

        public AddKegApiService()
        {
            _kegService = new KegService();
        }

        public Task<ResourceCreationResult<AddKeg, int>> CreateAsync(AddKeg resource, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context.UriParameters.GetByName<int>("OfficeId")
                .EnsureValue(() => context.CreateHttpResponseException<Keg>("The Office Id must be supplied in the URI", HttpStatusCode.BadRequest));
            var newKeg = new Repository.Model.Keg()
            {
                OfficeId = officeId,
                KegState = KegState.New,
                Size = KegConstant.NewKegSize
            };
            var newKegId = _kegService.Insert(newKeg);

            context.LinkParameters.Set(new LinksParametersSource(officeId, newKegId));
            resource.OfficeId = officeId;
            resource.Id = newKegId;


            return Task.FromResult(new ResourceCreationResult<AddKeg, int>(resource));
        }
    }
}