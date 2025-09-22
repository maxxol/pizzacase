using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizzacase
{
    internal class Pizza
    {
        private List<Topping>? toppings;
        private double price;
        private string name;
        public Pizza(List<Topping>? _toppings, string _name)
        {
            this.toppings =_toppings;
            this.name = _name;
            PriceData.ToppingPricing.TryGetValue(name, out this.price);
        }
        public double getPrice()
        {
            return price;
        }
    }
}
