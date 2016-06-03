using System.Collections.Generic;
using BeerTap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.WebApi.Hypermedia
{
    public class KegSpec : ResourceSpec<Keg, KegState, int>
    {

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Office({OfficeId})/Keg({id})");

        public override string EntrypointRelation
        {
            get { return LinkRelations.Keg; }
        }

        protected override IEnumerable<ResourceLinkTemplate<Keg>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.OfficeId, c => c.Id);
        }

        protected override IEnumerable<IResourceStateSpec<Keg, KegState, int>> GetStateSpecs()
        {
            yield return new ResourceStateSpec<Keg, KegState, int>(KegState.New)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.GetBeer, GetBeerSpec.Uri,c => c.OfficeId, c => c.Id ),
                },
                Operations =
                {
                       Get=ServiceOperations.Get,
                }

            };
        }
    }
}