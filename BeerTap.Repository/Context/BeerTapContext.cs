using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTap.Repository.Model;

namespace BeerTap.Repository.Context
{
    public class BeerTapContext : DbContext
    {
        public BeerTapContext() : base("BeerTapContext")
        {
            
        }

        public DbSet<Keg> Kegs { get; set; }
        public DbSet<Office> Offices { get; set; }
    }
}
