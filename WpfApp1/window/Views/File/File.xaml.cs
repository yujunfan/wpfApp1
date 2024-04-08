using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Model;




namespace WpfApp1.window.Views.File
{
    /// <summary>
    /// File.xaml 的交互逻辑
    /// </summary>
    public partial class File : System.Windows.Controls.Page
    {

        private int tempPage = 0;
        public File()
        {
            InitializeComponent();
            Pagination.PaginationVM.currentPage = 1;
            Pagination.paginationHandler -= Pagination_paginationHandler;
            Pagination.paginationHandler += Pagination_paginationHandler;
         
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void Pagination_paginationHandler(object sender, CommonControl.PaginationEventArg arg)
        {
            tempPage = arg._page;
            this.btnSearch_Click(this, null);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Pagination.PaginationVM.currentPage = 1;
            Pagination.PaginationVM.totalPage = 1;
            Pagination.PaginationVM.totalElements = 1;
        }


    }
}
