using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using FriendOrganizer.UI.Wrapper;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FriendOrganizer.UI.ViewModel
{
	public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
	{
		public ICommand SaveCommand { get; set; }
		public IEventAggregator EventAggregator { get; }
		private IFriendDataService DataService;
		private FriendWrapper friend;

		public FriendDetailViewModel(
			IFriendDataService dataService,
			IEventAggregator eventAggregator)
		{
			DataService = dataService;
			EventAggregator = eventAggregator;
			EventAggregator.GetEvent<OpenFriendDetailViewEvent>()
				.Subscribe(OnOpenFriendDetailView);

			SaveCommand = new DelegateCommand(OnSaveExecute, OnsaveCanExectute);
		}

		public async Task LoadAsync(int friendId)
		{
			Friend friend = await DataService.GetByIdAsync(friendId);
			Friend = new FriendWrapper(friend);
		}

		public FriendWrapper Friend {
			get { return friend; }
			set {
				friend = value;
				OnProperyChanged();
			}
		}

		private async void OnSaveExecute()
		{
			await DataService.SaveAsync(Friend.Model);
			EventAggregator.GetEvent<AfterFriendSavedEvent>().Publish(
				new AfterFriendSavedEventArgs
				{
					Id = Friend.Id,
					DisplayMember = $"{Friend.FirstName} {Friend.LastName}"
				});
		}

		private bool OnSaveCanExecute()
		{
			//TODO: check if friend is valid
			return true;
		}

		private async void OnOpenFriendDetailView(int friendId)
		{
			await LoadAsync(friendId);
		}

	}
}
