using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using todoApp.context;
using todoApp.layout;
using todoApp.login.dto;
using todoApp.login.service;

namespace todoApp.login.viewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        public LoginService service;
        public IRelayCommand LoginCommand { get; }
        private string _userId;
        public string UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        private string _userPwd;
        public string UserPwd
        {
            get => _userPwd;
            set => SetProperty(ref _userPwd, value);
        }


        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
            service = new LoginService();
        }

        private void Login()
        {
            var user = new UserDto() { Id = UserId, Password = UserPwd };
            var result = service.LoginVerification(user);
            if (result == null)
            {
                MessageBox.Show("로그인 실패");
                return;
            }
            SessionContext.LoginUserSession = user;
            Layout layout = new Layout();
            layout.Show();

            Application.Current.Windows.OfType<Login>().FirstOrDefault()?.Close();
        }
    }
}
