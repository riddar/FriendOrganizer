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
	public class MainViewModel : ViewModelBase
	{
		public ObservableCollection<Friend> Friends { get; set; }
		private IFriendDataService friendDataService;
		private Friend selectedFriend;

		public MainViewModel(IFriendDataService _friendDataService)
		{
			Friends = new ObservableCollection<Friend>();
			friendDataService = _friendDataService;
		}

		public async Task LoadAsync()
		{
			var friends = await friendDataService.GetAllAsync();
			foreach(var friend in friends)
			{
				Friends.Add(friend);
			}
		}

		public Friend SelectedFriend 
		{
			get { return selectedFriend; }
			set 
			{
				selectedFriend = value;
				OnProperyChanged();
			}
		}	
	}
}
