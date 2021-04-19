using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Filter.Controller
{
    public class FilterCollection
    {

        public event FilteredDataEventHandler OnChangeFilter;

        private readonly Control container;

        public List<Filter> Filters { get; private set; }
        public ComboBox Cap { get; private set; }
        public IEnumerable<object> Data { get; private set; }
        private void FillCap()
        {
            var element = Data?.First();
            Cap = new ComboBox();
            Cap.Items.AddRange(
                element
                .GetType()
                .GetProperties()
                .Where(x => x.GetCustomAttributes<FilterNameAttribute>().Count() > 0)
                .Select(x => x.GetCustomAttributes<FilterNameAttribute>()
                .First()
                .Name)
                .ToArray());
        }
        public FilterCollection(Control container, IEnumerable<object> data)
        {
            Filters = new List<Filter>();

            this.container = container;
            Data = data;
            FillCap();
            Redraw();

            OnChangeFilter?.Invoke(this, new FilteredDataEventArgs(Data));


        }
        private IEnumerable<object> GetFiltered()
        {
            if (Filters.Count == 0)
            {
                return Data;
            }
            List<object> data = new List<object>();
            foreach (var filter in Filters)
            {
                var filteringPortion = filter.StartFilter(Data);
                foreach (var result in filteringPortion)
                {
                    if (!data.Contains(result))
                    {

                        data.Add(result);
                    }
                }
            }
            return data;

        }

        private void OnChoiceNewFilter(object sender, EventArgs e)
        {
            PropertyInfo property = Data
                .First()
                .GetType()
                .GetProperties()
                .Where(x => x.GetCustomAttributes<FilterNameAttribute>().Count() > 0
                && x.GetCustomAttributes<FilterNameAttribute>().First().Name ==
                Cap.SelectedItem.ToString())
                .First();
            var filter = new Filter(property, Data);
            filter.OnChange += OnChangeFilteringConfiguration;
            Filters.Add(filter);
            Redraw();
        }
        private void TrimButton(Button button)
        {
            int minSize = button.Height;
            button.Width = (int)(button.Text.Length * 7);
            if (button.Width < minSize)
            {
                button.Width = minSize;
            }
        }
        private void TrimComboBox(ComboBox box)
        {
            int minSize = 30;
            box.Width = (int)(box.Items.OfType<object>().Select(x => x.ToString().Length).Max() * 7);
            if (box.Width < minSize)
            {
                box.Width = minSize;
            }
        }
        private void DrawControl(Control control, int top, ref int left, int additionLeft)
        {
            control.Left = left;
            control.Top = top;
            left += additionLeft + control.Width;

        }
        private void DeleteFilter(Filter filter)
        {

            container.Controls.Remove(filter.Data);
            container.Controls.Remove(filter.RemoveButton);
            Filters.Remove(filter);
            Redraw();
        }
        private void Redraw()
        {
            foreach (var item in Filters)
            {
                container.Controls.Remove(item.Data);
                container.Controls.Remove(item.RemoveButton);
            }
            container.Controls.Remove(Cap);
            FillCap();
            int offsetTop = 15;
            int offsetLeft = 10;
            int additionLeft = 5;
            TrimComboBox(Cap);
            foreach (var item in Filters)
            {

                TrimComboBox(item.Data);
                TrimButton(item.RemoveButton);
                DrawControl(item.Data, offsetTop, ref offsetLeft, additionLeft);
                DrawControl(item.RemoveButton, offsetTop, ref offsetLeft, additionLeft);
                item.RemoveButton.Click += (object sender, EventArgs e) => DeleteFilter(item);
                container.Controls.Add(item.Data);
                container.Controls.Add(item.RemoveButton);
            }
            DrawControl(Cap, offsetTop, ref offsetLeft, additionLeft);
            container.Controls.Add(Cap);
            Cap.SelectedIndexChanged += OnChoiceNewFilter;

            OnChangeFilter?.Invoke(this, new FilteredDataEventArgs(GetFiltered()));
        }
        private void OnChangeFilteringConfiguration(object sender, EventArgs e)
        {
            OnChangeFilter?.Invoke(this, new FilteredDataEventArgs(GetFiltered()));
        }
    }
}
