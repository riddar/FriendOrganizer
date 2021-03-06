﻿using FriendOrganizer.Model;
using FriendOrganizer.UI.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Wrapper
{
	public class FriendWrapper : ViewModelBase, INotifyDataErrorInfo
	{
		public Friend Model { get; }
		public int Id { get { return Model.Id; } }

		public FriendWrapper(Friend model)
		{
			Model = model;
		}

		public string FirstName {
			get { return Model.FirstName; }
			set 
			{
				Model.FirstName = value;
				OnProperyChanged();
				ValidateProperty(nameof(FirstName));
			}
		}

		private void ValidateProperty(string propertyName)
		{
			ClearErrors(propertyName);
			switch (propertyName)
			{
				case nameof(FirstName):
					if (string.Equals(FirstName, "robot", StringComparison.OrdinalIgnoreCase))
						AddError(propertyName, "Robots are not valid friends");
					break;
			}
		}

		public string LastName {
			get { return Model.LastName; }
			set 
			{
				Model.LastName = value;
				OnProperyChanged();
			}
		}

		public string Email {
			get { return Model.Email; }
			set 
			{
				Model.Email = value;
				OnProperyChanged();
			}
		}

		private Dictionary<string, List<string>> _errorsByPropertyName
			= new Dictionary<string, List<string>>();

		public bool HasErrors => _errorsByPropertyName.Any();

		public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

		public IEnumerable GetErrors(string propertyName)
		{
			return _errorsByPropertyName.ContainsKey(propertyName)
				? _errorsByPropertyName[propertyName]
				: null;
		}

		private void OnErrorsChanged(string propertyName)
		{
			ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
		}

		private void AddError(string propertyName, string error)
		{
			if (!_errorsByPropertyName.ContainsKey(propertyName))
				_errorsByPropertyName[propertyName] = new List<string>();
			if (!_errorsByPropertyName[propertyName].Contains(error))
			{
				_errorsByPropertyName[propertyName].Add(error);
				OnErrorsChanged(propertyName);
			}
		}

		private void ClearErrors(string propertyName)
		{
			if (_errorsByPropertyName.ContainsKey(propertyName))
			{
				_errorsByPropertyName.Remove(propertyName);
				OnErrorsChanged(propertyName);
			}
		}
	}
}
