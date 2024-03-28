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
using WpfApp1.window;
using WpfApp1.window.dataBind.addList;

namespace WpfApp1.window.layout
{
    /// <summary>
    /// Layout.xaml 的交互逻辑
    /// </summary>
    public partial class Layout : Page
    {
        public Layout()
        {
            InitializeComponent();
            SubFrame.Navigate(new Page1());
        }

        private void Button_Click(string value)
        {

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

        }
    }
}
