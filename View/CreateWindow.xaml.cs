using StudentRegistrationSystem.Models;
using StudentRegistrationSystem.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StudentRegistrationSystem.View
{
    /// <summary>
    /// Interaction logic for CreateWindow.xaml
    /// </summary>
    public partial class CreateWindow : Window
    {
        public CreateWindow()
        {
            DataContext = new CreateWindowVM();
            InitializeComponent();
        }


        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Window create = new CreateWindow();
            create.Show();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Window option = new HomeWindow();
            option.Show();
        }

        
    }
}
