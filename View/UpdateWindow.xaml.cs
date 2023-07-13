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
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        public UpdateWindow()
        {
            //DataContext = new ReadWindowVM();
            InitializeComponent();
        }

        private void BackSearch_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ScoreUpdate_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var viewModel = DataContext as ReadWindowVM;
            // Get the edited cell\
            //DataGridCell editedCell = new DataGridCell();
            var editedCell = e.EditingElement as TextBox;

            // Get the row and column index of the edited cell
            int rowIndex = e.Row.GetIndex();
            int columnIndex = e.Column.DisplayIndex;

            // Call a method in the view model to update the database
            viewModel.UpdateScore(rowIndex, columnIndex, editedCell);
        }

        private void ScoreUpdate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
