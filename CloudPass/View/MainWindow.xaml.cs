using CloudPass.ViewModels;  // Import the namespace containing DataManegerViewModel.
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
using CloudPass.Model;

namespace CloudPass
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Create an instance of DataManegerViewModel.
            DataManegerViewModel viewModel = new DataManegerViewModel();

            // Set the ViewModel as the DataContext for the main window.
            this.DataContext = viewModel;
        }
    }
}
