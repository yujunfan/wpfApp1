using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;



namespace WpfApp1.window.Views.Device
{
    /// <summary>
    /// Device.xaml 的交互逻辑
    /// </summary>
    public partial class Device : Page

    {
        private ObservableCollection<BluetoothDeviceInfo> _devices = new ObservableCollection<BluetoothDeviceInfo>();
        BluetoothClient client;
        public Device()
        {
            InitializeComponent();
            client = new BluetoothClient();
            FileDataGrid.ItemsSource = _devices;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            _devices.Clear();

            BluetoothClient bluetoothClient = new BluetoothClient();
            BluetoothDeviceInfo[] discoveredDevices = bluetoothClient.DiscoverDevices();

            foreach (BluetoothDeviceInfo deviceInfo in discoveredDevices)
            {
                _devices.Add(deviceInfo);
            }
        }

        private void ConnectBluetooth_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            BluetoothDeviceInfo info = btn.DataContext as BluetoothDeviceInfo;
            if (info.Connected)
            {

            }
            client.Connect(info.DeviceAddress, BluetoothService.SerialPort);

            if (client.Connected)
            {
                Console.WriteLine("Connected to device.");

                // 打开端口并监听数据传输
                Stream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead;

                try
                {
                    while (true)
                    {
                        // 读取数据
                        bytesRead = stream.Read(buffer, 0, buffer.Length);
                        if (bytesRead == 0)
                        {
                            // 连接已断开
                            Console.WriteLine("Connection closed by remote device.");
                            break;
                        }
                        string data = System.Text.Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        Console.WriteLine($"Received data: {data}");
                    }
                }
                catch (IOException ex)
                {
                    // 连接异常
                    Console.WriteLine($"Connection error: {ex.Message}");
                }
                finally
                {
                    // 关闭连接
                    client.Close();
                }


            }
            else
            {
                Console.WriteLine("Failed to connect to device.");
            }

        }

        private void FileDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
