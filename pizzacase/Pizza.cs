using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizzacase
{
    internal class Pizza : OrderedItem
    {
        private string name;
        public Pizza(List<Topping>? _toppings)
        {
            PriceData.BasePricing.TryGetValue("pizza", out this.basePrice);
            
            this.toppings =_toppings;
            this.name = "pizza";
            //PriceData.ToppingPricing.TryGetValue(name, out this.price);
        }
        
    }
}
