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
    /// Interaction logic for AdminLoginWindow.xaml
    /// </summary>
    public partial class AdminLoginWindow : Window
    {
        public AdminLoginWindow()
        {
            InitializeComponent();
        }

        private void Sign_In(object sender, RoutedEventArgs e)
        {
            string Password = PasswordTextBox.Password;
            if (Password == "1234")
            {
                UserCreateWindow secondWindow = new UserCreateWindow();
                secondWindow.Show();
                this.Close();
            }

            else
            {
                MessageBox.Show("Incorrect Password. Please try again!");
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Main_Menu(object sender, RoutedEventArgs e)
        {
            MainWindow secondWindow = new MainWindow();
            secondWindow.Show();
            this.Close();
        }
    }
}
