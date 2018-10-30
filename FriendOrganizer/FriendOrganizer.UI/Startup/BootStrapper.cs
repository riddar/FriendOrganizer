﻿using Autofac;
using FriendOrganizer.DataAccess;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.ViewModel;

namespace FriendOrganizer.UI.Startup
{
	public class Bootstrapper
	{
		public IContainer Boostrap()
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<FriendOrganizerDBContext>().AsSelf();
			builder.RegisterType<MainWindow>().AsSelf();
			builder.RegisterType<MainViewModel>().AsSelf();
			builder.RegisterType<FriendDataService>().As<IFriendDataService>();

			return builder.Build();
		}
	}
}
