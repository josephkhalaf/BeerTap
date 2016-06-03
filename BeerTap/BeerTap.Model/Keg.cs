using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.Model
{
    public class Keg : IStatefulResource<KegState>, IIdentifiable<int>
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public int OfficeId { get; set; }
        public KegState KegState { get; set; }
    }
}
