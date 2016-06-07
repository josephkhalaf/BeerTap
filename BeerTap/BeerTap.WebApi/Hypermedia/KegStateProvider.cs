using System.Collections.Generic;
using BeerTap.Model;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Hypermedia;

namespace BeerTap.WebApi.Hypermedia
{
    public class KegStateProvider : ResourceStateProviderBase<Keg, KegState>
    {
        public override KegState GetFor(Keg resource)
        {
            return resource.KegState;
        }

        protected override IDictionary<KegState, IEnumerable<KegState>> GetTransitions()
        {
            return new Dictionary<KegState, IEnumerable<KegState>>
            {
                {
                    KegState.New, new[]
                    {
                        KegState.GoinDown
                    }
                },
                {
                    KegState.GoinDown, new[]
                    {
                        KegState.AlmostEmpty                    
                    }
                },
                {
                     KegState.AlmostEmpty, new[]
                    {
                        KegState.SheIsDryMate
                    }
                },
                {
                     KegState.SheIsDryMate, new[]
                    {
                        KegState.New
                    }
                }
            };
        }

        public override IEnumerable<KegState> All
        {
            get { return EnumEx.GetValuesFor<KegState>(); }
        }
    }
}