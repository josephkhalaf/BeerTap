namespace BeerTap.Model
{
    /// <summary>
    /// iQmetrix link relation names
    /// </summary>
    public static class LinkRelations
    {
        /// <summary>
        /// link relation to describe the Identity resource.
        /// </summary>
        public const string SampleResource = "iq:SampleResource";
        public const string Office = "iq:Office";
        public const string Keg = "iq:Keg";
        public const string GetBeer = "iq:GetBeer";
        public const string ReplaceKeg = "iq:ReplaceKeg";
        public const string AddKeg = "iq:AddKeg";
    }
}
