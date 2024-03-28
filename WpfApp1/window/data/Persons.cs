using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Runtime.CompilerServices;






namespace WpfApp1.window.data
{
    public class Person : INotifyPropertyChanged
    {

        private string name;
        public string Id { get; set; }

        public bool isSelect;

        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged(); // 当属性更改时调用 OnPropertyChanged 方法
                }
            }
        }

        public bool IsSelect
        {
            get { return isSelect; }
            set
            {
                if (value != isSelect)
                {
                    isSelect = value;
                    OnPropertyChanged(); // 当属性更改时调用 OnPropertyChanged 方法
                }
            }
        }
        public string Email { get; set; }
        public string Member { get; set; }
        // 实现 INotifyPropertyChanged 接口
        public event PropertyChangedEventHandler PropertyChanged;

        // 创建一个方法来触发 PropertyChanged 事件
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
    public class Persons : ObservableCollection<Person>
    {
        public Persons()
        {
            Add(new Person { Name = "小明", Email = "666888@qq.com", Member = "1363633625441" });
            Add(new Person { Name = "小明", Email = "666888@qq.com", Member = "1363633625441" });
            Add(new Person { Name = "小明", Email = "666888@qq.com", Member = "1363633625441" });
            Add(new Person { Name = "小明", Email = "666888@qq.com", Member = "1363633625441" });
            Add(new Person { Name = "小明", Email = "666888@qq.com", Member = "1363633625441" });
        }
    }

    public class PersonsList : ObservableCollection<Person>
    {
        public PersonsList()
        {
            Add(new Person { Name = "小明", Email = "666888@qq.com", Member = "1363633625441" });
            Add(new Person { Name = "小明", Email = "666888@qq.com", Member = "1363633625441" });
            Add(new Person { Name = "小明", Email = "666888@qq.com", Member = "1363633625441" });
        }
    }
}
