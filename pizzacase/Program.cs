using pizzacase;
//---------------------------------setup---------------------------
PriceData.fillAllPricingDictionaries();
ShoppingCart shoppingCart = new ShoppingCart();

//-------------------------------main order------------------------
while (true)
{
    Console.Write("add pizza?: ");
    if (Console.ReadLine().ToLower() == "no") { break; };
    List<Topping> inputToppings = new List<Topping>();

    while (true)
    {
        Console.Write("[\"done\" to finish pizza] enter topping: ");
        string inputIngredient = Console.ReadLine().ToLower();
        if (inputIngredient == "done") { break; }
        inputToppings.Add(new Topping(inputIngredient));
    }
    shoppingCart.cartItems.Add(new Pizza(inputToppings));
}
Console.WriteLine(shoppingCart.GetTotalPrice()); 