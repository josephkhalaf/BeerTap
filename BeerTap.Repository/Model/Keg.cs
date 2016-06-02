namespace BeerTap.Repository.Model
{
    public class Keg
    {
        public int KegId { get; set; }
        public int Size { get; set; }
        public int OfficeId { get; set; }
        public Office Office { get; set; }
    }
}
