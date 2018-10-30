using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
	public class FriendDataService : IFriendDataService
	{
		private Func<FriendOrganizerDBContext> contextCreator;

		public FriendDataService(Func<FriendOrganizerDBContext> _contextCreator)
		{
			contextCreator = _contextCreator;
		}

		public async Task<IEnumerable<Friend>> GetAllAsync()
		{
			using (var ctx = contextCreator())
			{
				return await ctx.Friends.AsNoTracking().ToListAsync();
			}
		}
	}
}
