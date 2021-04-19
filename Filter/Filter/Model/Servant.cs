using Filter.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter.Model
{
    public class Servant
    {
        [FilterName("Имя")]
        public string Name { get; private set; }
        [FilterName("Редкость")]
        public int Rarity { get; private set; }
        [FilterName("Класс")]
        public ClassType Class { get; private set; }

        public Servant(string name, int rarity, ClassType classType)
        {
            Name = name;
            Rarity = rarity;
            Class = classType;
        }
        public override string ToString()
        {
            return $"{Rarity} stars. {Name} ({Class})";

        }
    }
}
