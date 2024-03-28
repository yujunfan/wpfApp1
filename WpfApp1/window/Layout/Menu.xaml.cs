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



namespace WpfApp1.window.Layout


{
    /// <summary>
    /// Menu.xaml 的交互逻辑
    /// </summary>
    public partial class Menu : UserControl
    {
        public static readonly DependencyProperty UsernameProperty =
                 DependencyProperty.Register("Username", typeof(string), typeof(Menu));

        public string Username
        {
            get { return (string)GetValue(UsernameProperty); }
            set { SetValue(UsernameProperty, value); }
        }

        public static readonly DependencyProperty MyClickProperty =
            DependencyProperty.Register("MyClick", typeof(Action<string>), typeof(Menu));

        public Action<string> MyClick
        {
            get { return (Action<string>)GetValue(MyClickProperty); }
            set { SetValue(MyClickProperty, value); }
        }

        public Menu()
        {
            InitializeComponent();
            DataContext = this; // 
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string value = button.Tag.ToString(); // 获取传递的值
            Console.WriteLine(Username + "aaaa");
            Username = value;
            MyClick?.Invoke(value);
        }
    }
}
