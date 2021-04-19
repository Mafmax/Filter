using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filter.Controller
{
    public class Filter
    {
        public event EventHandler OnChange;
        public PropertyInfo Property { get; private set; }
        public ComboBox Data { get; private set; }
        public Button RemoveButton { get; private set; }
        public string Name { get; private set; }

        public Filter(PropertyInfo property, IEnumerable<object> data)
        {
            var attrib = property
                .GetCustomAttributes<FilterNameAttribute>()
                .First();
            if(attrib != null)
            {
                Name = attrib.Name;
            }
            Property = property;
            Data = new ComboBox();
            RemoveButton = new Button();
            RemoveButton.Text = "-";
            Data.Sorted = true;
            foreach (var item in data)
            {
                var value = property.GetValue(item);
                if (!Data.Items.Contains(value))
                {
                    Data.Items.Add(value);
                }
            }
            Data.SelectedIndexChanged += OnFilterConditionChanged;
            Data.SelectedIndex = 0;
            OnChange?.Invoke(this, new EventArgs());
        }

        private void OnFilterConditionChanged(object sender, EventArgs e)
        {
            OnChange?.Invoke(this, e);
        }

        public IEnumerable<object> StartFilter(IEnumerable<object> data)
        {
            foreach (var item in data)
            {
                if (Property.GetValue(item).Equals(Data.SelectedItem))
                {
                yield return item;
                }
            }
        }
    }
}
