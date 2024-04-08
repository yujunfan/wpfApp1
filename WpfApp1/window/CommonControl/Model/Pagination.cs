using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.window.CommonControl.Model
{
    public class Pagination
    {
        public int currentPage { get; set; }
        public int totalPage { get; set; }
        public int totalElements { get; set; }
        /// <summary>
        /// 每一页显示条数
        /// </summary>
        public int pageElementNum { get; set; } = 20;
        public bool isSearch { get; set; } = false;
    }
}
