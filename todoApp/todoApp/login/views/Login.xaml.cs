using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using todoApp.layout;
using todoApp.login.viewModel;
using todoApp.views.home;

namespace todoApp
{
    /// <summary>
    /// Login.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            var vm = new LoginViewModel();
            this.DataContext = vm;
            vm.CloseAction = new Action(() => this.Close());
        }

        private void Pwd_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel vm)
            {
                vm.UserPwd = Pwd.Password;
            }
        }
    }
}
