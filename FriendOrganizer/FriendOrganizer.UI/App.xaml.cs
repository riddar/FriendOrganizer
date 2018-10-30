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
	}
}
