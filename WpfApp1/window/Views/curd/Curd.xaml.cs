using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.window.data;

namespace WpfApp1.window.Views.curd
{
    /// <summary>
    /// Curd.xaml 的交互逻辑
    /// </summary>
    public partial class Curd : Page
    {
        ObservableCollection<Person> persons = new ObservableCollection<Person>();
        public Curd()
        {
            InitializeComponent();
            DG2.DataContext = persons;
        }

        public void add(object sender, RoutedEventArgs e)
        {
            persons.Add(new Person { Name = "网啊啊", Email = "82799885@qq.com", Member = "99968541", isSelect = false });
            Console.WriteLine(persons.Count);

        }
        public void Update(object sender, RoutedEventArgs e)
        {
            if (DG2.SelectedItem != null)
            {
                // 获取选中的数据对象
                Person selectedPerson = DG2.SelectedItem as Person; // 假设数据对象是 Person 类型

                // 更新Name属性的值
                if (selectedPerson != null)
                {
                    selectedPerson.Name = "已更改";
                }
            }

        }

        public void Delete(object sender, RoutedEventArgs e)
        {
            if (DG2.SelectedItem != null)
            {
                persons.Remove((Person)DG2.SelectedItem);
            }

        }

        private void Batch_Detele(object sender, RoutedEventArgs e)
        {
            if (DG2.SelectedItem != null)
            {
                // 在此处实现更新逻辑
            }
        }

        private void List_All_Select(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.CheckBox checkBox = (System.Windows.Controls.CheckBox)sender;
            if (checkBox.IsChecked == true)
            {
                foreach (Person item in persons)
                {
                    item.IsSelect = true;
                }
                System.Diagnostics.Debug.WriteLine("全选了");
            }
            else
                foreach (Person item in persons)
                {
                    item.IsSelect = false;
                }
        }
    }
}
