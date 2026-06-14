using System.Configuration;
using System.Data;
using System.Windows;
using todoApp.context;
using todoApp.utill.SQL;

namespace todoApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SessionContext.SqlRapper = new SqlRapper();
            Login login = new();
            login.Show();
        }
    }

}
