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
using TService;



namespace WpfApp1.window
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            text.DataContext = Global.UserInfo.Email;
        }

        public void ShowMessage(object sender, RoutedEventArgs e)
        {

            var messageBoxText = this.messageBoxText.Text;
            var caption = this.caption.Text;
            var button = (MessageBoxButton)Enum.Parse(typeof(MessageBoxButton), buttonComboBox.Text);
            var icon = (MessageBoxImage)Enum.Parse(typeof(MessageBoxImage), imageComboBox.Text);
            var defaultResult =
                (MessageBoxResult)Enum.Parse(typeof(MessageBoxResult), defaultResultComboBox.Text);
            var options = (MessageBoxOptions)Enum.Parse(typeof(MessageBoxOptions), optionsComboBox.Text);


            // Show message box, passing the window owner if specified
            MessageBoxResult result;
            result = System.Windows.MessageBox.Show(messageBoxText, caption, button, icon, defaultResult, options);
        }

        public void ChangeData(object sender, RoutedEventArgs e)
        {
            Global.UserInfo.Email = new DateTime().Second.ToString() + "qq.com";

        }

        public void Test(object sender, RoutedEventArgs e)
        {
            var db = new DB();
            db.CreateTables();
            db.Test();

        }
    }
}
