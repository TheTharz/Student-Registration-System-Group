using StudentRegistrationSystem.ViewModels;
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

namespace StudentRegistrationSystem.View
{
    /// <summary>
    /// Interaction logic for ReadWindow.xaml
    /// </summary>
    public partial class ReadWindow : Window
    {
        public ReadWindow()
        {
            DataContext = new ReadWindowVM();
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            //this.Visibility = Visibility.Hidden;
        }

        private void Go_Back_Click(object sender, RoutedEventArgs e)
        {
           // this.Visibility = Visibility.Hidden;
           this.Close();
            Window MainW = new HomeWindow();
            MainW.Show();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            //this.Visibility = Visibility.Hidden;
            this.Close();
            //Window newW = new ModuleRegitrationWindow();
            //newW.Show();
        }
    }
}
