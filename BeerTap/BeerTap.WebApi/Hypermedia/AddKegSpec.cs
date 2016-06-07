using System.Collections.Generic;
using BeerTap.ApiServices;
using BeerTap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.WebApi.Hypermedia
{
    public class AddKegSpec : SingleStateResourceSpec<AddKeg, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({OfficeId})/AddKeg");

        public override string EntrypointRelation
        {
            get { return LinkRelations.AddKeg; }
        }

        protected override IEnumerable<ResourceLinkTemplate<AddKeg>> Links()
        {
            yield return CreateLinkTemplate<LinksParametersSource>(CommonLinkRelations.Self, Uri, x => x.Parameters.OfficeId);
        }

        public override IResourceStateSpec<AddKeg, NullState, int> StateSpec
        {
            get
            {
                return
                    new SingleStateSpec<AddKeg, int>
                    {
                        Links =
                        {
                            CreateLinkTemplate(LinkRelations.Keg, KegSpec.Uri,c => c.OfficeId, c => c.Id)
                        },
                        Operations =
                        {
                            InitialPost = ServiceOperations.Create
                        }
                    };
            }
        }
    }
}