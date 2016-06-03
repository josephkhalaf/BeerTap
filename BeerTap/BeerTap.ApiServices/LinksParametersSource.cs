namespace BeerTap.ApiServices
{
    /// <summary>
    /// The class is used to pass additional parameters to hypermedia links definitions in resource specifications.
    /// </summary>
    public class LinksParametersSource
    {
        public LinksParametersSource(int officeId, int kegId)
        {
            OfficeId = officeId;
            KegId = kegId;
        }

        public int OfficeId { get; private set; }
        public int KegId { get; private set; }


    }
}