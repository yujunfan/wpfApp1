using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class WorkSection 
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public WorkSection(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
