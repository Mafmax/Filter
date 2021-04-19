using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Filter.Controller;
using Filter.Model;

namespace Filter
{
    public partial class Form1 : Form
    {
        private List<Servant> Servants = new List<Servant>();
        public Form1()
        {
            InitializeComponent();

        }

        private void ConfigureServants()
        {
            Servants.Add(new Servant("Огурец", 4, ClassType.CASTER));
            Servants.Add(new Servant("Помидор", 4, ClassType.CASTER));
            Servants.Add(new Servant("Супер-овощ", 4, ClassType.CASTER));
            Servants.Add(new Servant("Супер-овощ", 3, ClassType.CASTER));
            Servants.Add(new Servant("Огурец", 2, ClassType.TANK));
            Servants.Add(new Servant("Огурец", 2, ClassType.TANK));
            Servants.Add(new Servant("Огурец", 2, ClassType.DAMAGER));
            Servants.Add(new Servant("Цапля", 1, ClassType.DAMAGER));
            Servants.Add(new Servant("Помидор", 1, ClassType.DAMAGER));
            Servants.Add(new Servant("Огурец", 2, ClassType.TANK));
            Servants.Add(new Servant("Ёж", 1, ClassType.HILLER));
            Servants.Add(new Servant("Огурец", 1, ClassType.HILLER));
        }
        private void filterGroup_Enter(object sender, EventArgs e)
        {
        }

        private void data_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void OnFilterChanged(object sender, FilteredDataEventArgs e)
        {
            data.Items.Clear();
            data.Items.AddRange(e.Data.ToArray());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigureServants();
            FilterCollection filters = new FilterCollection(filterGroup, Servants);
            filters.OnChangeFilter += OnFilterChanged;
            data.Items.AddRange(Servants.ToArray());

        }
    }
}
