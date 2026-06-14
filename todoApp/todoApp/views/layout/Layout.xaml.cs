using System.Windows;
using todoApp.views.checkList;
using todoApp.views.fileList;
using todoApp.views.home;

namespace todoApp.layout
{
    /// <summary>
    /// Layout.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Layout : Window
    {
        Home home { get; set; }
        CheckList checkList { get; set; }   
        public Layout()
        {
            InitializeComponent();
            home = new Home();
            MainContent.Content = home; 
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            home = new Home();
            MainContent.Content = home; 
        }

        private void CheckListButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CheckList();
        }
        private void FileListButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new FileList();
        }
        
    }
}
