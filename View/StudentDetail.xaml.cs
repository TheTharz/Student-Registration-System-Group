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
    /// Interaction logic for StudentDetail.xaml
    /// </summary>
    public partial class StudentDetail : Window
    {
        public StudentDetail()
        {
            InitializeComponent();
        }
        private void BackSearch_Click(object sender, RoutedEventArgs e)
        {
            //this.Visibility = Visibility.Hidden;
            this.Close();
            //Window Search = new ReadWindow();
            //Search.Show();
        }
    }
}
