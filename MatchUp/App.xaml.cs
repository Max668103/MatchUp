using MatchUp.ViewModel;
using MatchUp.Utilities;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MatchUp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        NavigationService.Navigation = new NavigationVM();

        NavigationService.Name = "";

        MainWindow mainWindow = new MainWindow
        {
            DataContext = NavigationService.Navigation
        };

        mainWindow.Show();
    }

}

