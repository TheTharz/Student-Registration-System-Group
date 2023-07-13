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
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Window create = new CreateWindow();
            create.Show();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Window updatewindow = new UpdateWindow();
            updatewindow.Show();
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Window readwindow = new ReadWindow();
            readwindow.Show();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Window deletewindow = new DeleteWindow();
            deletewindow.Show();
        }
    }
}
