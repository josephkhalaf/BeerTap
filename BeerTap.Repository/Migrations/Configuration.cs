using BeerTap.Model;
using Keg = BeerTap.Repository.Model.Keg;
using Office = BeerTap.Repository.Model.Office;

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
                  p => p.Id,
                  new Office { Name = "Vancouver" },
                  new Office { Name = "Regina" },
                  new Office { Name = "Winnipeg" },
                  new Office { Name = "Davidson" }
                );
            context.SaveChanges();

            var officeId = context.Offices.Single(o => o.Name == "Vancouver").Id;
            context.Kegs.AddOrUpdate(
                k => k.Id,
                new Keg { OfficeId = officeId, KegState = KegState.New, Size = 20000 },
                new Keg { OfficeId = officeId, KegState = KegState.GoinDown, Size = 15000 },
                new Keg { OfficeId = officeId, KegState = KegState.AlmostEmpty, Size = 2000 }
                );
            context.SaveChanges();

            officeId = context.Offices.Single(o => o.Name == "Regina").Id;
            context.Kegs.AddOrUpdate(
                k => k.Id,
                new Keg { OfficeId = officeId, KegState = KegState.SheIsDryMate, Size = 0 },
                new Keg { OfficeId = officeId, KegState = KegState.SheIsDryMate, Size = 0 },
                new Keg { OfficeId = officeId, KegState = KegState.AlmostEmpty, Size = 1000 }
                );
            context.SaveChanges();

            officeId = context.Offices.Single(o => o.Name == "Winnipeg").Id;
            context.Kegs.AddOrUpdate(
                k => k.Id,
                new Keg { OfficeId = officeId, KegState = KegState.New, Size = 20000 },
                new Keg { OfficeId = officeId, KegState = KegState.New, Size = 20000 },
                new Keg { OfficeId = officeId, KegState = KegState.New, Size = 20000 }
                );
            context.SaveChanges();
        }
    }
}
