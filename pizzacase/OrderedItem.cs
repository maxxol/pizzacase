using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace pizzacase
{
    internal class OrderedItem
    {
        public List<Topping> toppings;
        public double basePrice;
        //public double price;
    
        public double getPrice()
            {
                double toppingsPrice = 0;

                foreach (Topping topping in toppings) { 
                PriceData.ToppingPricing.TryGetValue(topping.name, out double value); 
                toppingsPrice += value;
                Console.WriteLine(value + " added");
                }
                Console.WriteLine("for total toppingprice of "+ toppingsPrice);
                
                double price = basePrice + toppingsPrice;
            Console.WriteLine("item has total price of "+price);
                return price;
            }
    } 
}
