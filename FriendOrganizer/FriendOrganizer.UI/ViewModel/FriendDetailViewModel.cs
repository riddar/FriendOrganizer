using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using Prism.Events;
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

		public FriendDetailViewModel(
			IFriendDataService dataService,
			IEventAggregator eventAggregator)
		{
			DataService = dataService;
			EventAggregator = eventAggregator;
			EventAggregator.GetEvent<OpenFriendDetailViewEvent>()
				.Subscribe(OnOpenFriendDetailView);
		}

		private async void OnOpenFriendDetailView(int friendId)
		{
			await LoadAsync(friendId);
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

		public IEventAggregator EventAggregator { get; }
	}
}
