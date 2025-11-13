using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizzacase
{
    internal class Ingredient
    {
        public string name;
        protected double price;
        public Ingredient(string _name)
        {
            this.name = _name;
        }
    }
}
