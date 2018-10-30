using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.DataAccess
{
	public class FriendOrganizerDBContext : DbContext
	{
		public FriendOrganizerDBContext() : base("FriendOrganizerDB") { }
		public DbSet<Friend> Friends { get; set; }

		protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
		{
			base.OnModelCreating(dbModelBuilder);
			dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
