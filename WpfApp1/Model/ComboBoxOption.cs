using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class ComboBoxOption
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ComboBoxOption(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
