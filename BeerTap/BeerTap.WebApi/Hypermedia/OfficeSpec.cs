using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerTap.ApiServices;
using BeerTap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTap.WebApi.Hypermedia
{
    public class OfficeSpec : SingleStateResourceSpec<Office, int>
    {

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({id})");

        public override string EntrypointRelation
        {
            get { return LinkRelations.Office; }
        }

        protected override IEnumerable<ResourceLinkTemplate<Office>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.Id);
        }

        public override IResourceStateSpec<Office, NullState, int> StateSpec
        {
            get
            {
                return new SingleStateSpec<Office, int>
                {
                    Links =
                   {
                   },
                    Operations =
                   {
                       Get=ServiceOperations.Get,
                       Post = ServiceOperations.Update,
                       Delete = ServiceOperations.Delete,
                       InitialPost = ServiceOperations.Create
                   }
                };
            }
        }
    }
}