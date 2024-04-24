using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
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


    public delegate void SerialPortEventHandler(Object sender, SerialPortEventArgs e);

    public class SerialPortEventArgs : EventArgs
    {
        public bool isOpend = false;
        public Byte[] receivedBytes = null;
    }

    /// <summary>
    /// Device.xaml 的交互逻辑
    /// </summary>
    public partial class Device : Page

    {
        private SerialPort sp = new SerialPort();
        private ObservableCollection<BluetoothDeviceInfo> _devices = new ObservableCollection<BluetoothDeviceInfo>();
        private ObservableCollection<SerialPort> _splist = new ObservableCollection<SerialPort>();



        public event SerialPortEventHandler comReceiveDataEvent = null;
        public event SerialPortEventHandler comOpenEvent = null;
        public event SerialPortEventHandler comCloseEvent = null;
        private Object thisLock = new Object();

        BluetoothClient client;
        public Device()
        {
            InitializeComponent();
            client = new BluetoothClient();
            FileDataGrid.ItemsSource = _devices;
            serialPortGrid.ItemsSource = _splist;

            GetBlueToothData();
            GetSerialPortData();
        }

        /// <summary>
        /// When serial received data, will call this method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (sp.BytesToRead <= 0)
            {
                return;
            }
            lock (thisLock)
            {
                int len = sp.BytesToRead;
                Byte[] data = new Byte[len];
                try
                {
                    sp.Read(data, 0, len);
                }
                catch (System.Exception)
                {
                    //catch read exception
                }
                SerialPortEventArgs args = new SerialPortEventArgs();
                args.receivedBytes = data;

            }
        }

        /// <summary>
        /// Send bytes to device
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public bool Send(Byte[] bytes)
        {
            if (!sp.IsOpen)
            {
                return false;
            }

            try
            {
                sp.Write(bytes, 0, bytes.Length);
            }
            catch (System.Exception)
            {
                return false;   //write failed
            }
            return true;        //write successfully
        }



        /// <summary>
        /// Open Serial port
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        /// <param name="dataBits"></param>
        /// <param name="stopBits"></param>
        /// <param name="parity"></param>
        /// <param name="handshake"></param>
        public void Open(string portName, String baudRate,
            string dataBits, string stopBits, string parity,
            string handshake)
        {
            if (sp.IsOpen)
            {
                Close();
            }
            sp.PortName = portName;
            sp.BaudRate = Convert.ToInt32(baudRate);
            sp.DataBits = Convert.ToInt16(dataBits);
            if (handshake == "None")
            {
                sp.RtsEnable = true;
                sp.DtrEnable = true;
            }

            SerialPortEventArgs args = new SerialPortEventArgs();
            try
            {
                sp.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBits);
                sp.Parity = (Parity)Enum.Parse(typeof(Parity), parity);
                sp.Handshake = (Handshake)Enum.Parse(typeof(Handshake), handshake);
                sp.WriteTimeout = 1000; /*Write time out*/
                sp.Open();
                Global.ZJClientConnection.Opened = true;
                sp.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
                args.isOpend = true;
            }
            catch (System.Exception)
            {
                args.isOpend = false;
                Global.ZJClientConnection.Opened = false;
            }
            if (comOpenEvent != null)
            {
                comOpenEvent.Invoke(this, args);
            }

        }

        public void Close()
        {
            Thread closeThread = new Thread(new ThreadStart(CloseSpThread));
            closeThread.Start();
            Global.ZJClientConnection.Opened = false;
        }

        private void CloseSpThread()
        {
            SerialPortEventArgs args = new SerialPortEventArgs();
            args.isOpend = false;
            try
            {
                sp.Close(); //close the serial port
                sp.DataReceived -= new SerialDataReceivedEventHandler(DataReceived);
            }
            catch (Exception)
            {
                args.isOpend = true;
            }
            if (comCloseEvent != null)
            {
                comCloseEvent.Invoke(this, args);
            }

        }


        /// <summary>
        /// 获取蓝牙设备列表
        /// </summary>

        private async void GetBlueToothData()
        {

            _devices.Clear();

            await System.Threading.Tasks.Task.Run(() =>
            {
                BluetoothClient bluetoothClient = new BluetoothClient();
                BluetoothDeviceInfo[] discoveredDevices = bluetoothClient.DiscoverDevices();
                foreach (BluetoothDeviceInfo deviceInfo in discoveredDevices)
                {
                    // 在 UI 线程上更新集合
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        _devices.Add(deviceInfo);
                    });

                }
            });
        }



        /// <summary>
        /// 获取蓝牙设备列表
        /// </summary>

        private async void GetSerialPortData()
        {

            _splist.Clear();

            await System.Threading.Tasks.Task.Run(() =>
            {
                string[] portNames = SerialPort.GetPortNames();
                foreach (string portName in portNames)
                {
                    Console.WriteLine($"Port: {portName}");

                    try
                    {
                        // 创建 SerialPort 对象
                        using (SerialPort port = new SerialPort(portName))
                        {
                            _splist.Add(port);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error accessing port {portName}: {ex.Message}");
                    }

                    Console.WriteLine();
                }
            });
        }




        /// <summary>
        /// 串口连接操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectSP_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.IsEnabled = false;
            btn.Content = "已连接";

            SerialPort info = btn.DataContext as SerialPort;
            this.Open(info.PortName, info.BaudRate.ToString(), info.DataBits.ToString(), "One", "None", "None");
        }

        /// <summary>
        /// 小车连接操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CarConnect(Button btn, BluetoothDeviceInfo info)
        {
            if (info.Connected)
            {
                Global.CarConnection.Connected = false;
            }
            try
            {
                client.Connect(info.DeviceAddress, BluetoothService.SerialPort);
                Global.CarConnection.Connected = true;
            }
            catch (IOException ex)
            {
                // 连接异常
                Console.WriteLine($"Connection error: {ex.Message}");
                Global.CarConnection.Connected = false;
            }



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
 
            }
        }

        /// <summary>
        /// 打印机连接操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrinterConnect(Button btn, BluetoothDeviceInfo info)
        {
            Global.PrinterConnection.Connected = !Global.PrinterConnection.Connected;
        }

        private void ConnectBluetooth_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            BluetoothDeviceInfo info = btn.DataContext as BluetoothDeviceInfo;
            if(info.ClassOfDevice.MajorDevice == DeviceClass.Phone)
            {
                CarConnect(btn, info);
            }

            if(info.ClassOfDevice.MajorDevice == DeviceClass.AudioVideoUnclassified)
            {
                PrinterConnect(btn, info);
            }


        }
    }
}
