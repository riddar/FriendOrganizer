using System;
using System.Windows;
using Autofac;
using FriendOrganizer.UI.Startup;

namespace FriendOrganizer.UI
{
	public partial class App : Application
	{
		private void Application_Startup(object sender, StartupEventArgs e)
		{
			//MainWindow MainWindow = new MainWindow(new MainViewModel(new FriendDataService()));
			var boostrapper = new Bootstrapper();
			var container = boostrapper.Boostrap();
			var mainWindow = container.Resolve<MainWindow>();
			MainWindow.Show();
		}

		private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
		{
			MessageBox.Show("Unexpected Error occured."
				+ Environment.newLine + e.Exception, "Unexpected error");
			e.Handled = true;
		}
	}
}
