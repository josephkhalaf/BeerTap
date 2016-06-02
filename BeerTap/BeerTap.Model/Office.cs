using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.Model
{
    public class Office : IStatelessResource, IIdentifiable<int>
    {
        public string Name { get; set; }
        public int Id { get; }
    }
}
