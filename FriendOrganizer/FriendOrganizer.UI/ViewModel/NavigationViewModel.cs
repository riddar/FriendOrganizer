using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
	public class NavigationViewModel : ViewModelBase, INavigationViewModel
	{

		public ObservableCollection<NavigationItemViewModel> Friends { get; }
		public IEventAggregator EventAggregator { get; }
		private ILookupDataService LookupDataService;
		private NavigationItemViewModel selectedFriend;

		public NavigationViewModel(
			ILookupDataService lookupDataService,
			IEventAggregator eventAggregator)
		{
			LookupDataService = lookupDataService;
			EventAggregator = eventAggregator;
			Friends = new ObservableCollection<NavigationItemViewModel>();
			EventAggregator.GetEvent<AfterFriendSavedEvent>().Subscribe(AfterFriendSaved);
		}

		private void AfterFriendSaved(AfterFriendSavedEventArgs obj)
		{
			var lookupItem = Friends.Single(l => l.Id == obj.Id);
			lookupItem.DisplayMember = obj.DisplayMember;
		}

		public async Task LoadAsync()
		{
			var lookup = await LookupDataService.GetFriendLookupAsync();
			foreach(var item in lookup)
			{
				Friends.Add(new NavigationItemViewModel(item.Id, item.DisplayMember));
			}
		}

		public NavigationItemViewModel SelectedFriend {
			get { return selectedFriend; }
			set {
				selectedFriend = value;
				OnProperyChanged();
				if(selectedFriend != null)
					EventAggregator.GetEvent<OpenFriendDetailViewEvent>()
						.Publish(selectedFriend.Id);
			}
		}

	}
}
