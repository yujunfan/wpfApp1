using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.window.CommonControl.ViewModel
{
    public class PaginationVM : INotifyPropertyChanged
    {

        public PaginationVM()
        {
            _pagination = new Model.Pagination();
        }

        public Model.Pagination _pagination;

        /// <summary>
        /// 当前页
        /// </summary>
        public int currentPage
        {
            get { return _pagination.currentPage; }
            set { _pagination.currentPage = value; RaisePropertyChanged("currentPage"); }
        }
        /// <summary>
        /// 总页数
        /// </summary>
        public int totalPage
        {
            get { return _pagination.totalPage; }
            set { _pagination.totalPage = value; RaisePropertyChanged("totalPage"); }
        }

        /// <summary>
        /// 元素总个数
        /// </summary>
        public int totalElements
        {
            get { return _pagination.totalElements; }
            set { _pagination.totalElements = value; RaisePropertyChanged("totalElements"); }
        }
        /// <summary>
        /// 是否在搜索状态
        /// </summary>
        public bool isSearch
        {
            get { return _pagination.isSearch; }
            set { _pagination.isSearch = value; }
        }

        /// <summary>
        /// 每页显示条数
        /// </summary>
        public int pageElementNum
        {
            get { return _pagination.pageElementNum; }
            set { _pagination.pageElementNum = value; RaisePropertyChanged("pageElementNum"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
