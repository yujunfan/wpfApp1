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
using WpfApp1.window.Views.Device;

namespace WpfApp1.window.CommonControl
{
    /// <summary>
    /// DeviceConnectControl.xaml 的交互逻辑
    /// </summary>
    public partial class DeviceConnectControl : UserControl
    {
        public DeviceConnectControl()
        {
            InitializeComponent();
            Global.CarConnection.VariableChanged += CarConnectChange;
            Global.PrinterConnection.VariableChanged += PrinterConnectChange;
            Global.ZJClientConnection.VariableChanged += ZJClientConnectionChange;
        }

        private void CarConnectChange(object sender, EventArgs e)
        {
            if (Global.CarConnection.Connected)
            {
                this.Dispatcher.Invoke(() =>
                {
                    carText.Text = "小车已连接";
                    carImage.Source = new BitmapImage(new Uri("/Resources/Common/active_car.png", UriKind.Relative));
                    carButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00B61D"));
                });





            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    carText.Text = "小车未连接";
                    carImage.Source = new BitmapImage(new Uri("/Resources/Common/unactive_car.png", UriKind.Relative));
                    carButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C3C3C3"));
                });

            
            }
        }

        private void PrinterConnectChange(object sender, EventArgs e)
        {

            if (Global.PrinterConnection.Connected)
            {
                this.Dispatcher.Invoke(() =>
                {
                    printerText.Text = "打印机已连接";
                    printerImage.Source = new BitmapImage(new Uri("/Resources/Common/active_printer.png", UriKind.Relative));
                    printerButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00B61D"));
                });


            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    printerText.Text = "打印机未连接";
                    printerImage.Source = new BitmapImage(new Uri("/Resources/Common/unactive_printer.png", UriKind.Relative));
                    printerButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C3C3C3"));
                });

            }
        }

        private void ZJClientConnectionChange(object sender, EventArgs e)
        {
            if (Global.ZJClientConnection.Opened)
            {
                this.Dispatcher.Invoke(() =>
                {
                    zjText.Text = "仲景已连接";
                    zjImage.Source = new BitmapImage(new Uri("/Resources/Common/active_zj.png", UriKind.Relative));
                    zjButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00B61D"));
                });

            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    zjText.Text = "仲景未连接";
                    zjImage.Source = new BitmapImage(new Uri("/Resources/Common/unactive_zj.png", UriKind.Relative));
                    zjButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C3C3C3"));
                });
                
            }
        }
    }
}
