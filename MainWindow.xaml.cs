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
using WpfApp1.window.layout;
using MahApps.Metro.Controls;
using WpfApp1.window.dataBind.addList;


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
            SubFrame.Navigate(new Page1());
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
                case "page1":
                    SubFrame.NavigationService.Navigate(new Page1());
                    break;
                case "page2":
                    SubFrame.NavigationService.Navigate(new Page2());
                    break;
                case "addList":
                    SubFrame.NavigationService.Navigate(new addList());
                    break;
                default:
                    SubFrame.NavigationService.Navigate(new Page3());
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


        private void OpenDialogButton_Click(object sender, RoutedEventArgs e)
        {
            // 创建并显示对话框
            var dialog = new Window1(); // MyDialog 是你自定义的对话框窗口
            dialog.Owner = this; // 将主窗口设置为对话框的 Owner，这会使对话框在主窗口上方显示，并将其设为模态
            dialog.ShowDialog(); // 显示对话框，代码会暂停直到对话框关闭为止
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void MainFrame_Navigated_1(object sender, NavigationEventArgs e)
        {

        }

 


    }
}
