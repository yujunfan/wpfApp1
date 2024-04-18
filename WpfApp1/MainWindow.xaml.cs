using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.window;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using WpfApp1;
using WpfApp1.window.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;


public class YourViewModel : INotifyPropertyChanged
{
    private string _currentButton;

    public string CurrentButton
    {
        get { return _currentButton; }
        set
        {
            if (_currentButton != value)
            {
                _currentButton = value;
                OnPropertyChanged("CurrentButton");
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class DataContextWrapper
{
    public MainWindow Window { get; set; }
    public YourViewModel ViewModel { get; set; }
}

namespace WpfApp1
{




    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private YourViewModel viewModel;
        string path = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            SubFrame.Navigate(new HBLayout());
            //  MainFrame.NavigationService.Navigate(new Layout());
            // 创建 ViewModel 实例并作为窗口的数据上下文
            viewModel = new YourViewModel();

            viewModel.CurrentButton = "hahah";

            this.DataContext = viewModel;

        }



        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string value = button.Tag.ToString(); // 获取传递的值
            switch (value)
            {
                case "hblayout":
                    SubFrame.NavigationService.Navigate(new HBLayout());
                    break;
                default:
                    SubFrame.NavigationService.Navigate(new HBLayout());
                    break;
            }
            //MyClick?.Invoke(value);
        }

        private void LaunchGitHubSite(object sender, RoutedEventArgs e)
        {
            // Launch the GitHub site...
        }

        private void DeployCupCakes(object sender, RoutedEventArgs e)
        {
            // deploy some CupCakes...
        }




        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void MainFrame_Navigated_1(object sender, NavigationEventArgs e)
        {

        }

        private void SubFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
