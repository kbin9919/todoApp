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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 1. Frame 생성
            Frame frame = new Frame
            {
                NavigationUIVisibility = NavigationUIVisibility.Hidden,
                Source = new Uri("views/home/Home.xaml", UriKind.Relative) // 상대 경로
            };

            // 2. 새 Window 생성해서 Frame 삽입
            Window mainWindow = new Window
            {
                Title = "메인 화면",
                Content = frame,
                Width = 1000,
                Height = 800
            };

            // 3. 창 띄우기 + 현재 로그인 창 닫기
            mainWindow.Show();
            this.Close();
        }
    }
}
