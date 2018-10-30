using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
	public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
	{
		private IFriendDataService DataService;
		private Friend friend;

		public FriendDetailViewModel(IFriendDataService dataService)
		{
			DataService = dataService;
		}

		public async Task LoadAsync(int friendId)
		{
			Friend = await DataService.GetByIdAsync(friendId);
		}

		public Friend Friend {
			get { return friend; }
			set 
			{
				friend = value;
				OnProperyChanged();
			}
		}
	}
}
