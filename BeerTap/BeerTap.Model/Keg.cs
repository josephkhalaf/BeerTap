using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerTap.Model
{
    public class Keg
    {
        public int KegId { get; set; }
        public int Size { get; set; }
        public int OfficeId { get; set; }
        public KegState KegState { get; set; }
    }
}
