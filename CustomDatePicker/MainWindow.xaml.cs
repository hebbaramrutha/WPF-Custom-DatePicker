using System.Windows;

namespace CustomDatePicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainVM _customerVm;

        public MainWindow()
        {
            InitializeComponent();
            _customerVm = new MainVM();
            DataContext = _customerVm;
        }

        /// <summary>
        /// Method added to check view model property value after date selection. Added only for testing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_customerVm.DateOfBirth.ToString());
        }
    }
}
