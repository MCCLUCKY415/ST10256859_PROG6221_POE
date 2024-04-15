using System;

namespace ST10256859_PROG6221_POE_PART1.Classes
{
    public class Ingredients
    {
        public string IngName { get; set; }
        public string IngUnitOfMeasure { get; set; }
        public double IngQuantity { get; set; }
        public double OriginalIngQuantity { get; set; }
        public int NumIngredients { get; set; } = 0;

        public Ingredients[] GetIngredients()
        {
            bool inputValid = false;

            while (!inputValid)
            {
                try
                {
                    Console.Write("\n\nPlease enter the total number of ingredients that will be used: ");
                    NumIngredients = Convert.ToInt32(Console.ReadLine());
                    inputValid = true;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease enter a number!");
                    Console.ResetColor();
                    continue;
                }

                Ingredients[] ing = new Ingredients[NumIngredients];
                for (int i = 0; i < NumIngredients; i++)
                {
                    Console.Write("\nPlease enter the name of ingredient " + (i + 1) + ": ");
                    string name = Console.ReadLine();

                    Console.Write("\nPlease enter the unit of measurement that will be used for ingredient " + (i + 1) + " (tablespoons, litres, etc.): ");
                    string measurement = Console.ReadLine();

                    double quantity = 0;
                    bool quantityValid = false;

                    while (!quantityValid)
                    {
                        try
                        {
                            Console.Write("\nPlease enter the quantity of measurements for ingredient " + (i + 1) + ": ");
                            quantity = Convert.ToDouble(Console.ReadLine());
                            quantityValid = true;
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nPlease enter a number!");
                            Console.ResetColor();
                            continue;
                        }
                    }

                    ing[i] = new Ingredients { IngName = name, IngQuantity = quantity, IngUnitOfMeasure = measurement, OriginalIngQuantity = quantity };
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\nIngredients successfully saved!\n\n");
                Console.ResetColor();
                return ing;
            }
            return null;
        }
    }
}