using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class GetBeer : IStatelessResource, IIdentifiable<int>
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public int OfficeId { get; set; }
    }
}
