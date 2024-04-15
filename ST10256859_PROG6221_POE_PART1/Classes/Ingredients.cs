// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References: List of references:
//             https://stackoverflow.com/questions/71967411/how-can-i-try-catch-an-exception-for-a-negative-number-in-c
//             https://youtu.be/QqWfw_CFR6Q?si=OWgC9KPJosQBqu5V
//             https://youtu.be/IHMmPVEOT64?si=FN64GWD1dU8C1i4E
//             GitHub Copilot for assisting with the structure of the code.
//             Microsoft Copilot for assisting me with finding and fixing errors in the code.

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

                    if (NumIngredients <= 0 || NumIngredients > 1000000000)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nPlease enter a valid number!");
                        Console.ResetColor();
                        continue;
                    }

                    inputValid = true;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nPlease enter a number!");
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

                            if (quantity <= 0 || quantity > 1000000000)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\nPlease enter a valid number!\n");
                                Console.ResetColor();
                                continue;
                            }

                            quantityValid = true;
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\nPlease enter a number!\n");
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