using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

//Defines the customer object
public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool IsMember { get; set; }
    public int Status { get; set; }
}

namespace WpfApp1.window.Views
{
    /// <summary>
    /// DataBind.xaml 的交互逻辑
    /// </summary>
    public partial class DataBind : Page
    {
        string test = "bbbb";
        public DataBind()
        {
            InitializeComponent();
            //GetData() creates a collection of Customer data from a database
            ObservableCollection<Customer> custdata = GetData();

            //Bind the DataGrid to the customer data
            DG1.DataContext = custdata;
        }
        public ObservableCollection<Customer> GetData()
        {
            ObservableCollection<Customer> custdata = new ObservableCollection<Customer>();

            // Your existing data retrieval logic...
            // e.g., custdata.Add(new Customer { Name = "John Doe" });

            // Add some additional data
            custdata.Add(new Customer
            {
                FirstName = "New Customer 1",
                LastName = "lastName",
                Email = "827115823@qq.com",
                IsMember = true,
                Status = 1
            });
            custdata.Add(new Customer
            {
                FirstName = "New Customer 1",
                LastName = "lastName",
                Email = "827115823@qq.com",
                IsMember = true,
                Status = 1
            });

            return custdata;
        }



        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            // this.ShowMessageAsync("This is the title", "Some message");
        }

    }
}
