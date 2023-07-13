using StudentRegistrationSystem.Models;
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
    /// Interaction logic for ModuleRegitrationWindow.xaml
    /// </summary>
    public partial class ModuleRegitrationWindow : Window
    {
        public ModuleRegitrationWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewModel = DataContext as ReadWindowVM;

            if (viewModel != null)
            {
                viewModel.GetSelectedData();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //this.Visibility = Visibility.Hidden;
            Window window = new ReadWindow();
            window.Show();
        }
    }
}
