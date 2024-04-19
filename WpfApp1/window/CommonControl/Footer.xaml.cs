using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace WpfApp1.window.CommonControl
{
    /// <summary>
    /// Footer.xaml 的交互逻辑
    /// </summary>
    public partial class Footer : UserControl
    {
        public Footer()
        {
            InitializeComponent();
            intCurrentTime();
        }
        private void ChangeNotice(object sender, MouseButtonEventArgs e)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        }

        /// <summary>
        /// 显示系统时间
        /// </summary>
        private void intCurrentTime()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1;
            timer.Elapsed += (a, e) =>
            {
                try
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        currenTime.Text = "当前时间：" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    });
                }
                catch (Exception error)
                {

                }


            };
            timer.AutoReset = true;
            timer.Start();

        }
    }
}
