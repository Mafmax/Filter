using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter.Controller
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FilterNameAttribute:Attribute
    {
        public FilterNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
