using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.window;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           InitializeComponent();
            MainFrame.NavigationService.Navigate(new Page2());
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string value = button.Tag.ToString(); // 获取传递的值
            switch (value)
            {
                case "page1":
                    MainFrame.NavigationService.Navigate(new Page1());
                    break;
                case "page2":
                    MainFrame.NavigationService.Navigate(new Page2());
                    break;
                default:
                    MainFrame.NavigationService.Navigate(new Page3());
                    break;
            }
                 
           
        }
    }
}
