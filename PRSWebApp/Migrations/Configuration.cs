namespace PRSWebApp.Migrations
{
	using PRSWebApp.Models;
	using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PRSWebApp.Models.PRSWebAppContext>
    {
        public Configuration()
        {
			//migrations will be done manually
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PRSWebApp.Models.PRSWebAppContext context)
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
			
			
			// will add following records if they do not already exist, will update them if they do exist
			context.Users.AddOrUpdate(
				u => u.UserName,
				new User {
					UserName = "admin",
					Password = "admin",
					FirstName = "system",
					LastName = "admin",
					Phone = "000-000-000",
					Email = "system@admin.com",
					IsReviewer = true,
					IsAdmin = true
				},

				new User {
					UserName = "user",
					Password = "user",
					FirstName = "Normal",
					LastName = "User",
					Phone = "000-000-000",
					Email = "normal@user.com",
					IsReviewer = false,
					IsAdmin = false
				}
				);

			context.Vendors.AddOrUpdate(
				v => v.Code,
				new Vendor {
					Code = "AMZ",
					Name = "Amazon",
					Address = "3680 Langley Drive",
					City = "Hebron",
					State = "KY",
					Zip = "41048",
					Phone = "859-292-3500",
					Email = "customerservice@amazon.com",
					IsPreapproved = true
				}
				);
		}
    }
}
