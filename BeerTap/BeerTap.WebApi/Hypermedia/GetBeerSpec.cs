using System.Collections.Generic;
using BeerTap.ApiServices;
using BeerTap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.WebApi.Hypermedia
{
    public class GetBeerSpec : SingleStateResourceSpec<GetBeer, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({OfficeId})/Keg({Id})/GetBeer");

        public override string EntrypointRelation
        {
            get { return LinkRelations.GetBeer; }
        }

        protected override IEnumerable<ResourceLinkTemplate<GetBeer>> Links()
        {
            yield return CreateLinkTemplate<LinksParametersSource>(CommonLinkRelations.Self, Uri, x => x.Parameters.OfficeId, x => x.Parameters.KegId);
        }

        public override IResourceStateSpec<GetBeer, NullState, int> StateSpec
        {
            get
            {
                return
                    new SingleStateSpec<GetBeer, int>
                    {
                        Operations =
                        {
                            InitialPost = ServiceOperations.Create
                        }
                    };
            }
        }
    }
}