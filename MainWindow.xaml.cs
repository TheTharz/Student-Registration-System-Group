using StudentRegistrationSystem.View;
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

namespace StudentRegistrationSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var username = UserNameTextBox.Text;
            var password = PasswordTextBox.Password;

            if (string.IsNullOrEmpty(UserNameTextBox.Text) && string.IsNullOrEmpty(PasswordTextBox.Password))
            {
                MessageBox.Show("Please Enter User Name and Password.");
            }
            else if (string.IsNullOrEmpty(UserNameTextBox.Text))
            {
                MessageBox.Show("Please Enter User Name.");

            }
            else if (string.IsNullOrEmpty(PasswordTextBox.Password))
            {
                MessageBox.Show("Please Enter Password.");
            }

            else
            {
                using (DataBaseContext context = new DataBaseContext())
                {
                    bool userfound = context.Users.Any(User => User.UserName == username && User.Password == password);

                    if (userfound)
                    {
                        HomeWindow secondwindow = new HomeWindow();
                        secondwindow.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("User Not Found or Incorrect Password");
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminLoginWindow secondWindow = new AdminLoginWindow();
            secondWindow.Show();
            this.Close();
        }
    }
}
