using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizzacase
{
    class OrderFormatter
    {
        public static string FormatOrder(ShoppingCart cart, string clientName)
        {
            var sb = new StringBuilder();

            sb.AppendLine(clientName); //naam klant
            foreach (Pizza item in cart.cartItems)
            {
                sb.AppendLine(item.name);                         // Naam van de pizza
                sb.AppendLine(item.quantity.ToString());          // Aantal pizza’s
                sb.AppendLine(item.toppings.Count.ToString());    // Aantal extra toppings

                foreach (Topping topping in item.toppings)            // Elke extra topping
                {
                    sb.AppendLine(topping.name);
                }
            }
            sb.AppendLine(DateTime.Now.ToString());

            return sb.ToString().TrimEnd();
        }

    }
}
