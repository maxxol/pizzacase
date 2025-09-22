using pizzacase;

PriceData.fillAllPricingDictionaries();

Console.Write("order pizza:");
string inputPizza = Console.ReadLine().ToLower();

Pizza testpizza = new Pizza(new List<Topping>(), inputPizza);
Console.WriteLine(testpizza.getPrice());
