using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
	public class NavigationItemViewModel : ViewModelBase
	{
		private string displayMember;
		public int Id { get; }

		public NavigationItemViewModel(int id, string displayMember)
		{
			Id = id;
			this.displayMember = displayMember;
		}

		public string DisplayMember {
			get { return displayMember; }
			set 
			{
				displayMember = value;
				OnProperyChanged();
			}
		}



	}
}
