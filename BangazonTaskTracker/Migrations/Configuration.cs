namespace BangazonTaskTracker.Migrations
{
    using Microsoft.Ajax.Utilities;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Runtime.Remoting.Contexts;
    using System.Web.UI.WebControls;

    internal sealed class Configuration : DbMigrationsConfiguration<BangazonTaskTracker.DAL.UserTaskContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BangazonTaskTracker.DAL.UserTaskContext context)
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



            context.UserTasks.AddOrUpdate(
                p => p.Id,
                new UserTask
                {
                    Name = "Design New Logo",
                    Description = "Something with cats, please.",
                    Status = 0
                },
                new UserTask
                {
                    Name = "Update Product Catalogue",
                    Description = "We now sell cat toys and small appliances",
                    Status = 0
                },
                new UserTask
                {
                    Name = "Hire At Least 43 New Developers",
                    Description = "This one's urgent",
                    Status = 0
                }

            );

        }
    }
}

