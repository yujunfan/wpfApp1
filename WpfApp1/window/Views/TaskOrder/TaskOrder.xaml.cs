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

namespace WpfApp1.window.Views.TaskOrder
{
    /// <summary>
    /// TaskOrder.xaml 的交互逻辑
    /// </summary>
    public partial class TaskOrder : Page
    {
        public TaskOrder()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // 替换 YOUR_API_KEY 为你从高德开放平台获取的 API Key
            //string url = "https://webapi.amap.com/maps?v=1.4.15&key=e8238c2a7489a292818c94a14b117ba1&&plugin=AMap.Geocoder,AMap.ToolBar,AMap.Geolocation,AMap.Autocomplete,AMap.Driving";
            //webBrowser.Navigate(url);

        }
    }
}
