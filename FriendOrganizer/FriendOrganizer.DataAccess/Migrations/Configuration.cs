namespace FriendOrganizer.DataAccess.Migrations
{
	using FriendOrganizer.Model;
	using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FriendOrganizerDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FriendOrganizerDBContext context)
        {
			context.Friends.AddOrUpdate(f => f.FirstName,
			new Friend { FirstName = "Thomas", LastName = "Huber" },
			new Friend { FirstName = "Andreas", LastName = "Boehler" },
			new Friend { FirstName = "Julia", LastName = "Huber" },
			new Friend { FirstName = "Chrissi", LastName = "Egin" }
			);
        }
    }
}
