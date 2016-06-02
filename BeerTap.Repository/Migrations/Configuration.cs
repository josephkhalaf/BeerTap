using BeerTap.Repository.Model;

namespace BeerTap.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BeerTap.Repository.Context.BeerTapContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BeerTap.Repository.Context.BeerTapContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Offices.AddOrUpdate(
                p => p.OfficeId,
                new Office() { OfficeId = 1, Name = "Vancouver" },
                new Office() { OfficeId = 2, Name = "Regina" },
                new Office() { OfficeId = 3, Name = "Winnipeg" },
                new Office() { OfficeId = 4, Name = "Davidson" }
                );


            context.Kegs.AddOrUpdate(
                p => p.KegId,
                //vancouver
                new Keg() { KegId = 1, Size = 1000, OfficeId = 1},
                new Keg() { KegId = 2, Size = 2000, OfficeId = 1},
                //regina
                new Keg() { KegId = 3, Size = 5000, OfficeId = 2},
                //winnipeg
                new Keg() { KegId = 4, Size = 1500, OfficeId = 3},
                new Keg() { KegId = 5, Size = 1500, OfficeId = 3 },
                new Keg() { KegId = 6, Size = 1500, OfficeId = 3 }
                );
        }
    }
}
