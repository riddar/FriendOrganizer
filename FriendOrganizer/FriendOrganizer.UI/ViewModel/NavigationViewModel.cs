using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
	public class NavigationViewModel : INavigationViewModel
	{
		private ILookupDataService lookupDataService;
		public ObservableCollection<LookupItem> Friends { get; }

		public NavigationViewModel(ILookupDataService _lookupDataService)
		{
			lookupDataService = _lookupDataService;
			Friends = new ObservableCollection<LookupItem>();
		}

		public async Task LoadAsync()
		{
			var lookup = await lookupDataService.GetFriendLookupAsync();
			foreach(var item in lookup)
			{
				Friends.Add(item);
			}
		}
	}
}
