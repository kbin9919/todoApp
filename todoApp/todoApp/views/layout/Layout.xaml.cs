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
using System.Windows.Shapes;
using todoApp.views.checkList;
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
    }
}
