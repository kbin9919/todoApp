using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using todoApp.context;
using todoApp.layout;
using todoApp.login.service;
using todoApp.login.verification;
using todoApp.login.vo;
using todoApp.utill;

namespace todoApp.login.viewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public ICommand LoginCommand { get; }
        public LoginService LoginService { get; set; }
        public Action CloseAction { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login, CheckFrontLogin);
            LoginService = new LoginService();
        }

        public string _userId;
        public string UserId
        {
            get => _userId;
            set
            {
                _userId = value;
                OnPropertyChanged(nameof(_userId));
            }
        }
        private string _userPwd;
        public string UserPwd
        {
            get => _userPwd;
            set
            {
                _userPwd = value;
                OnPropertyChanged(nameof(_userPwd));
            }
        }

        private bool CheckFrontLogin(object parameter)
        {
            // 로그인 버튼 활성화 조건 (예: ID가 비어있지 않으면 true)
            return true;
        }

        private void Login(object parameter)
        {
            UserVo vo = new UserVo() { Id = UserId, Pwd = UserPwd };

            var loginResult = LoginService.LoginVerification(vo);
            
            if (LoginChainResult.Fail.Equals(loginResult))
            {
                // 로그인 실패 - 잘못된 아이디 또는 비밀번호
            }
            else if (LoginChainResult.NotFoundInputData.Equals(loginResult))
            {
                // 로그인 실패 - 입력 데이터 없음
            }
            else if (LoginChainResult.NotFoundUserData.Equals(loginResult))
            {
                // 로그인 실패 - 사용자 데이터 없음
            }
            else if (LoginChainResult.Success.Equals(loginResult))
            {
                SessionContext.LoginUserSession = vo;

                var layout = new Layout();
                layout.Show();
                CloseAction?.Invoke();
            }
        }
    }
}
