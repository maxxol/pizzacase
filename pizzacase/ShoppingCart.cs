using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizzacase
{
    internal class ShoppingCart
    {
        public List<OrderedItem> cartItems;
        public double totalPrice;
        public ShoppingCart()
        { 
            cartItems = new List<OrderedItem>();
            
        }

        public double GetTotalPrice()
        {
            this.totalPrice = 0;
            foreach (OrderedItem cartItem in this.cartItems)
            {
                this.totalPrice+=cartItem.getPrice();
            }

            return this.totalPrice;
        }
    }
}
