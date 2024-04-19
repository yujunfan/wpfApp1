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
using WpfApp1.window.ViewModels;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Windows.Media;
using Brush = System.Drawing.Brush;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;

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

            Global.BluetoothInfo.VariableChanged += ConnectChange;
            Global.SerialPortInfo.VariableChanged += SerialPortChange;
        }


        private void ConnectChange(object sender, EventArgs e)
        {
            if (Global.BluetoothInfo.Connected && Global.BluetoothInfo.deviceName == "car")
            {
                carText.Text = "小车已连接";
                carImage.Source = new BitmapImage(new Uri("/Resources/Common/active_car.png", UriKind.Relative));
                carButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00B61D"));
                printerText.Text = "打印机未连接";
                printerImage.Source = new BitmapImage(new Uri("/Resources/Common/unactive_printer.png", UriKind.Relative));
                printerButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C3C3C3"));

            }
            else if (Global.BluetoothInfo.Connected && Global.BluetoothInfo.deviceName == "printer")
            {
                printerText.Text = "打印机已连接";
                printerImage.Source = new BitmapImage(new Uri("/Resources/Common/active_printer.png", UriKind.Relative));
                printerButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00B61D"));
                carText.Text = "小车未连接";
                carImage.Source = new BitmapImage(new Uri("/Resources/Common/unactive_car.png", UriKind.Relative));
                carButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C3C3C3"));
            }
            else
            {
                carText.Text = "小车未连接";
                carImage.Source = new BitmapImage(new Uri("/Resources/Common/unactive_car.png", UriKind.Relative));
                carButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C3C3C3"));
                printerText.Text = "打印机未连接";
                printerImage.Source = new BitmapImage(new Uri("/Resources/Common/unactive_printer.png", UriKind.Relative));
                printerButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C3C3C3"));
            }
        }
        private void SerialPortChange(object sender, EventArgs e)
        {
            if (Global.SerialPortInfo.Opened)
            {
                zjText.Text = "仲景已连接";
                zjImage.Source = new BitmapImage(new Uri("/Resources/Common/active_zj.png", UriKind.Relative));
                zjButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00B61D"));
            }
            else
            {
                zjText.Text = "仲景未连接";
                zjImage.Source = new BitmapImage(new Uri("/Resources/Common/unactive_zj.png", UriKind.Relative));
                zjButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C3C3C3"));
            }
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

        private void ConnectCar(object sender, RoutedEventArgs e)
        {
            // 在按钮点击事件中设置 BluetoothInfo 的信息
            Global.BluetoothInfo.deviceName = "car";
            Global.BluetoothInfo.Connected = !Global.BluetoothInfo.Connected;
            Global.BluetoothInfo.deviceName = "car";
        }

        private void ConnectPrinter(object sender, RoutedEventArgs e)
        {
            // 在按钮点击事件中设置 BluetoothInfo 的信息
            Global.BluetoothInfo.deviceName = "printer";
            Global.BluetoothInfo.Connected = !Global.BluetoothInfo.Connected;
            Global.BluetoothInfo.deviceName = "printer";
        }


        private void ConnectZJ(object sender, RoutedEventArgs e)
        {   // 在按钮点击事件中设置 BluetoothInfo 的信息
            Global.SerialPortInfo.Opened = !Global.SerialPortInfo.Opened;

        }
    }
}
