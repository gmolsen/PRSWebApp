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
			// will add this record if it does not exist, will update if it does
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
				}
				);
        }
    }
}
