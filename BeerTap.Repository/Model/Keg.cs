using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BeerTap.Model;

namespace BeerTap.Repository.Model
{
    public class Keg
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Size { get; set; }
        public int OfficeId { get; set; }
        public Office Office { get; set; }
        public KegState KegState { get; set; }


    }
}
