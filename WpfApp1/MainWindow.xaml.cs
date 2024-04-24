using WpfApp1.window.Views;
using MahApps.Metro.Controls;


namespace WpfApp1
{
    public partial class MainWindow : MetroWindow
    {

        public MainWindow()
        {
            InitializeComponent();
            SubFrame.Navigate(new HBLayout());

        }
    }
}
