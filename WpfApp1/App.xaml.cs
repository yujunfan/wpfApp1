using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Global.UserInfo.UserName = "6666";
            Global.UserInfo.Email = "827115823@qq.com";
            Global.UserInfo.Phone = "1666666";
        }
    }
}
