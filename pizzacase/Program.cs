using pizzacase;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
//---------------------------------setup---------------------------
PriceData.fillAllPricingDictionaries();
ShoppingCart shoppingCart = new ShoppingCart();
string clientName;

string privateKey = "p4X9uD1fL7qW2sN8rC5tJ0vH6yZ3kM1b";


//-------------------------------main order------------------------
while (true)
{
    clientName = "schrijvershof";


    Console.Write("add pizza?: ");
    if (Console.ReadLine().ToLower() == "no") { break; };
    List<Topping> inputToppings = new List<Topping>();
    int quantity;

    while (true)
    {
        while (true)
        {
            Console.Write("[\"done\" to finish pizza] enter topping: ");
            string inputIngredient = Console.ReadLine().ToLower();
            if (inputIngredient == "done") { break; }
            inputToppings.Add(new Topping(inputIngredient));
        }

        Console.Write("how many of this item: ");
        try
        {
            quantity = Convert.ToInt32(Console.ReadLine());
        }
        catch { continue; }
        break;
    }
    shoppingCart.cartItems.Add(new Pizza(inputToppings,quantity));
}
Console.Clear();
string formattedOrder = OrderFormatter.FormatOrder(shoppingCart, clientName);
Console.WriteLine("order confirmation:");
Console.WriteLine(formattedOrder);
Console.WriteLine("total price: $"+shoppingCart.GetTotalPrice());

InternetClient.getInstance().sendData("TCP",formattedOrder, privateKey);