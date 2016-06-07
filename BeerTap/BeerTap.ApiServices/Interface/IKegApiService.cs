using BeerTap.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTap.ApiServices.Interface
{
    public interface IKegApiService : IGetAResourceAsync<Keg, int>,
        IGetManyOfAResourceAsync<Keg, int>
    {
    }
}
