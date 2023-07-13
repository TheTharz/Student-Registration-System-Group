using StudentRegistrationSystem.Models;
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
    /// Interaction logic for UserCreateWindow.xaml
    /// </summary>
    public partial class UserCreateWindow : Window

    {
        public List<User> DatabaseUsers { get; private set; }
        public UserCreateWindow()
        {
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            var username = UserNameTextBox.Text;
            var password = PasswordTextBox.Text;

            if (string.IsNullOrEmpty(UserNameTextBox.Text) && string.IsNullOrEmpty(PasswordTextBox.Text))
            {
                MessageBox.Show("Please Give User Name and Password");
            }
            else if (string.IsNullOrEmpty(UserNameTextBox.Text))
            {
                MessageBox.Show("Please Give a User Name.");

            }
            else if (string.IsNullOrEmpty(PasswordTextBox.Text))
            {
                MessageBox.Show("Please Give a Password.");
            }
            else
            {
                using (DataBaseContext context = new DataBaseContext())
                {

                    if (context.Users.Any(u => u.UserName == username))
                    {
                        MessageBox.Show("A user with the same username already exists.");
                    }
                    else
                    {
                        context.Users.Add(new User() { UserName = username, Password = password });
                        context.SaveChanges();

                        //UserNameTextBox.Text = "";
                        //PasswordTextBox.Text = "";

                        ItemList.ItemsSource = context.Users.ToList();
                        MessageBox.Show("User is Added Successfully!");
                        
                    }
                }
            }
        }
        //private void ItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (ItemList.SelectedItem != null)
        //    {
        //        User selectedUser = (User)ItemList.SelectedItem;
        //        UserNameTextBox.Text = selectedUser.UserName;
        //        PasswordTextBox.Text = selectedUser.Password;
        //    }
        //}

        private void View(object sender, RoutedEventArgs e)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                ItemList.ItemsSource = context.Users.ToList();

            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            View(sender, e);
        }

        private void Main_Menu(object sender, RoutedEventArgs e)
        {
            MainWindow secondWindow = new MainWindow();
            secondWindow.Show();
            this.Close();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            using (DataBaseContext context = new DataBaseContext())
            {
                User selectedUser = ItemList.SelectedItem as User;

                if (selectedUser == null)
                {
                    MessageBox.Show("Please Select a User First to Delete.");
                    return;
                }

                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this user?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {

                    User user = context.Users.Single(x => x.Id == selectedUser.Id);


                    if (user == null)
                    {
                        MessageBox.Show("Selected User has already been deleted.");
                        return;
                    }

                    context.Remove(user);
                    context.SaveChanges();

                    ItemList.ItemsSource = context.Users.ToList();
                    MessageBox.Show("Delete Success!");
                }
            }
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            using (DataBaseContext context = new DataBaseContext())
            {

                User selectedUser = ItemList.SelectedItem as User;

                if (selectedUser == null)
                {
                    MessageBox.Show("Please Select a User First to Update.");
                    return;
                }

                var userName = UserNameTextBox.Text;
                var password = PasswordTextBox.Text;

                if (string.IsNullOrEmpty(UserNameTextBox.Text) && string.IsNullOrEmpty(PasswordTextBox.Text))
                {
                    MessageBox.Show("Please Enter New User Name and Password.");
                }
                else if (string.IsNullOrEmpty(UserNameTextBox.Text))
                {
                    MessageBox.Show("Please Enter New User Name.");
                }
                else if (string.IsNullOrEmpty(PasswordTextBox.Text))
                {
                    MessageBox.Show("Please Enter New Password.");
                }
                else if (userName != null && password != null)
                {

                    User user = context.Users.Find(selectedUser.Id);
                    user.UserName = userName;
                    user.Password = password;

                    context.SaveChanges();
                    ItemList.ItemsSource = context.Users.ToList();
                    MessageBox.Show("Update Success!");

                }

            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
