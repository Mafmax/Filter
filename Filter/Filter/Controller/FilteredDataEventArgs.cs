using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter.Controller
{
   public class FilteredDataEventArgs
    {
        public IEnumerable<object> Data { get; private set; }
        public FilteredDataEventArgs(IEnumerable<object> data)
        {
            Data = data ?? new object[0];
        }
    }
}
