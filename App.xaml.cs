using DoubleClickCommand.Store;
using DoubleClickCommand.ViewModel;
using DoubleClickCommand.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DoubleClickCommand
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
       private MainWindow main;
       private VMMainWindows vMMainWindow;
       private VMLogin login;
       private VMSearchEmail searchEmail;
        private UserStore userStore;

        App()
        {
            this.main = new MainWindow();
            this.userStore = new UserStore();
            this.login = new VMLogin(this.userStore);
            this.searchEmail = new VMSearchEmail(this.userStore);
            this.vMMainWindow = new VMMainWindows(login, searchEmail);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            this.main.DataContext = vMMainWindow;
            this.main.Show();
        }
    }
}
