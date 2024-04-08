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
using WpfApp1.window.CommonControl.ViewModel;
using WpfApp1.window.ViewModels;
namespace WpfApp1.window.CommonControl
{
    public delegate void PaginationHandler(object sender, PaginationEventArg arg);

    /// <summary>
    /// Pagination.xaml 的交互逻辑
    /// </summary>
    public partial class Pagination : UserControl
    {

        public ViewModel.PaginationVM PaginationVM;
        int currentSize;
        public Pagination()
        {
            InitializeComponent();
            PaginationVM = base.DataContext as ViewModel.PaginationVM;
            currentSize = PaginationVM.pageElementNum;
        }
        public event PaginationHandler paginationHandler;
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            if (PaginationVM.currentPage < PaginationVM.totalPage)
            {
                paginationHandler(this, new PaginationEventArg(PaginationVM.currentPage + 1, PaginationVM.isSearch, PaginationVM.pageElementNum));
            }
            else
                Behide2Popup.IsOpen = true;
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (PaginationVM.currentPage > 1)
            {
                paginationHandler(this, new PaginationEventArg(PaginationVM.currentPage - 1, PaginationVM.isSearch, PaginationVM.pageElementNum));
            }
            else
                front2Popup.IsOpen = true;
        }


        /// <summary>
        /// 去到某一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GOTO_Click(object sender, RoutedEventArgs e)
        {
            int gotopage;
            if (int.TryParse(gotoPage.Text, out gotopage))
            {
                if (gotopage <= PaginationVM.totalPage && gotopage > 0)
                {
                    paginationHandler(this, new PaginationEventArg(gotopage, PaginationVM.isSearch, PaginationVM.pageElementNum));
                }
                else
                {
                    GotoPopup.IsOpen = true;
                    return;
                }
            }
            else
            {
                MessageBox.Show("请输入正确的数字！");
                gotoPage.Text = PaginationVM.currentPage.ToString();
            }
        }

        private void GoToLast_Click(object sender, RoutedEventArgs e)
        {
            if (PaginationVM.currentPage == PaginationVM.totalPage)
                BehidePopup.IsOpen = true;
            else
                paginationHandler(this, new PaginationEventArg(PaginationVM.totalPage, PaginationVM.isSearch, PaginationVM.pageElementNum));
        }

        private void GoToFirst_Click(object sender, RoutedEventArgs e)
        {
            if (PaginationVM.currentPage == 1)
                frontPopup.IsOpen = true;
            else
                paginationHandler(this, new PaginationEventArg(1, PaginationVM.isSearch, PaginationVM.pageElementNum));
        }
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Refersh_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            paginationHandler(this, new PaginationEventArg(PaginationVM.currentPage, PaginationVM.isSearch, PaginationVM.pageElementNum));
        }

        /// <summary>
        /// 改变每页显示条数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrEmpty(pageSize.Text))
                {
                    int size;
                    if (int.TryParse(pageSize.Text, out size))
                    {
                        if (PaginationVM != null)
                        {
                            if (size > 500)
                                pageSize.Text = "500";
                            if (size < 1)
                                size = 1;
                            pageSize.Text = "1";
                            PaginationVM.pageElementNum = size;
                            int currentPage = (PaginationVM.currentPage - 1) * currentSize / PaginationVM.pageElementNum + 1;
                            currentSize = PaginationVM.pageElementNum;
                            PaginationVM.currentPage = currentPage;
                            paginationHandler(this, new PaginationEventArg(currentPage, PaginationVM.isSearch, PaginationVM.pageElementNum));
                        }
                    }
                    else
                    {
                        MessageBox.Show("请输入正确的数字！");
                        gotoPage.Text = PaginationVM.pageElementNum.ToString();
                    }
                }
                else
                    MessageBox.Show("请输入每页显示的信息条数！");
            }
        }

        private void PageSize_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

            pageSize.Focus();
            e.Handled = true;
        }

        private void PageSize_GotFocus(object sender, RoutedEventArgs e)
        {
            pageSize.SelectAll();
            pageSize.PreviewMouseDown -= new MouseButtonEventHandler(PageSize_PreviewMouseDown);
        }

        private void PageSize_LostFocus(object sender, RoutedEventArgs e)
        {
            pageSize.Text = PaginationVM.pageElementNum.ToString();
            pageSize.PreviewMouseDown += new MouseButtonEventHandler(PageSize_PreviewMouseDown);
        }
    }


    public class PaginationEventArg : EventArgs
    {
        public int _page { get; set; }
        public bool _isSearch { get; set; }
        public int _pageElementNum { get; set; }
        public PaginationEventArg(int page, bool isSearch, int pageElementNum)
        {
            _page = page;
            _isSearch = isSearch;
            _pageElementNum = pageElementNum;
        }
    }
}


/// <summary>
/// 
/// </summary>
