using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTap.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices.Interface
{
    public interface IKegApiService : IGetAResourceAsync<Keg, int>,
        IGetManyOfAResourceAsync<Keg, int>
    {
    }
}
