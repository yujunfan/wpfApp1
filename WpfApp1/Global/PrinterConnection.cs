using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Global
{
    public static class PrinterConnection
    {
        public static event EventHandler VariableChanged;

        public static string deviceName;
        public static string deviceAddress;
        public static bool connected;

        public static bool Connected
        {
            get { return connected; }
            set
            {
                connected = value;
                OnConnectedChanged(EventArgs.Empty);
            }
        }
        // 当全局变量改变时调用此方法来触发事件
        private static void OnConnectedChanged(EventArgs e)
        {
            VariableChanged?.Invoke(null, e);
        }
    }
}
