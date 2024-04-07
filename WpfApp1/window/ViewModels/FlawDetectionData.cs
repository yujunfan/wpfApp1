using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.window.ViewModels
{
    public class FlawDetectionData : BaseViewModel
    {
        public List<ComboBoxOption> workSectionData;
        public List<ComboBoxOption> xianbie;
        public List<ComboBoxOption> hangbie;
        public List<ComboBoxOption> gubie;
        public List<ComboBoxOption> timeType;
        public List<ComboBoxOption> status;
        public List<ComboBoxOption> WorkSectionData
        {
            get { return workSectionData; }
            set { workSectionData = value; }
        }
        public List<ComboBoxOption> Xianbie
        {
            get { return xianbie; }
            set { xianbie = value; }
        }
        public List<ComboBoxOption> Hangbie
        {
            get { return hangbie; }
            set { hangbie = value; }
        }
        public List<ComboBoxOption> Gubie
        {
            get { return gubie; }
            set { gubie = value; }
        }
        public List<ComboBoxOption> TimeType
        {
            get { return timeType; }
            set { timeType = value; }
        }
        public List<ComboBoxOption> Status
        {
            get { return status; }
            set { status = value; }
        }
        public FlawDetectionData()
        {
            this.workSectionData = new List<ComboBoxOption>(); // 初始化列表
            this.timeType = new List<ComboBoxOption>();
            this.status = new List<ComboBoxOption>();  
            this.xianbie = new List<ComboBoxOption>();
            this.gubie = new List<ComboBoxOption>();
            this.hangbie = new List<ComboBoxOption>();
            this.SetData();
        }


        public void SetData()
        {
            workSectionData.Add(new ComboBoxOption("aaa", "工务段A"));
            timeType.Add(new ComboBoxOption("aaa", "工务段A"));
            status.Add(new ComboBoxOption("aaa", "工务段A"));
            xianbie.Add(new ComboBoxOption("aaa", "工务段A"));
            hangbie.Add(new ComboBoxOption("aaa", "工务段A"));
            gubie.Add(new ComboBoxOption("aaa", "工务段A"));
        }
    }
}
