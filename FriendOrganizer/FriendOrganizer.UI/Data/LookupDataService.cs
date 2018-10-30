using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
	public class LookupDataService : ILookupDataService
	{
		private Func<FriendOrganizerDBContext> contextCreator;

		public LookupDataService(Func<FriendOrganizerDBContext> _contextCreator)
		{
			contextCreator = _contextCreator;
		}

		public async Task<IEnumerable<LookupItem>> GetFriendLookupAsync()
		{
			using (var ctx = contextCreator())
			{
				return await ctx.Friends.AsNoTracking().Select(f => new LookupItem {
					Id = f.Id,
					DisplayMember = f.FirstName + " " + f.LastName
				}).ToListAsync();
			}
		}
	}
}
