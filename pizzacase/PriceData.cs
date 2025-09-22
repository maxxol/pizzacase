using System;
using System.Collections.Generic;
using System.IO;

namespace pizzacase
{
    static class PriceData
    {
        public static Dictionary<string, double> ToppingPricing = new Dictionary<string, double>();

        // Method to fill a dictionary from a CSV file
        

        // Fill the pricing dictionaries
        public static void fillAllPricingDictionaries()
        {
            fillToppingPricing();
            // Additional methods to populate other pricing dictionaries can go here later
        }

        // Fills the ToppingPricing dictionary specifically
        static void fillToppingPricing()
        {
            fillDictionaryFromCsv("../../../ToppingPricing.csv", ToppingPricing);
        }



        static void fillDictionaryFromCsv(string filepath, Dictionary<string, double> dictionaryToFill)
        {
            try
            {
                string[] lines = File.ReadAllLines(filepath);
                foreach (var line in lines)
                {
                    string[] columns = line.Split(',');

                    if (columns.Length == 2)
                    {
                        string pizzaName = columns[0].Trim();
                        if (double.TryParse(columns[1].Trim(), out double pizzaPrice))
                        {
                            // Add to the dictionary
                            //Console.WriteLine(pizzaName,pizzaPrice);
                            dictionaryToFill[pizzaName] = pizzaPrice;
                        }
                        else
                        {
                            Console.WriteLine($"Error parsing price for pizza: {pizzaName}. Invalid format.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Skipping invalid line: {line}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }
    }
}
