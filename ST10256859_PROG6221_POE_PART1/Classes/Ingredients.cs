// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References:
// - Stack Overflow: https://stackoverflow.com/questions/71967411/how-can-i-try-catch-an-exception-for-a-negative-number-in-c
// - YouTube: https://youtu.be/QqWfw_CFR6Q?si=OWgC9KPJosQBqu5V
// - YouTube: https://youtu.be/IHMmPVEOT64?si=FN64GWD1dU8C1i4E
// - YouTube: https://youtu.be/aNTDJ9bnRU4?si=2f7p21l9Uz2IPAam
// - GitHub Copilot for assisting with the structure of the code.
// - Microsoft Copilot for assisting me with finding and fixing errors in the code.

using System;
using System.Collections.Generic;

namespace ST10256859_PROG6221_POE_PART1.Classes
{
    // This class is responsible for handling the ingredients of a recipe.
    public class Ingredients
    {
        // Properties for ingredient details
        public string IngName { get; set; }  // The name of the ingredient.
        public string IngUnitOfMeasure { get; set; }  // The unit of measurement for the ingredient (e.g., tablespoons, teaspoons, litres, etc.).
        public double IngQuantity { get; set; }  // The quantity of the ingredient.
        public double OriginalIngQuantity { get; set; }  // The original quantity of the ingredient. This is used for resetting quantities after scaling.
        public string OriginalIngUnitOfMeasure { get; set; }  // The original unit of measurement for the ingredient. This is used for resetting units of measurement after scaling.
        public double Calories { get; set; }  // The number of calories.
        public double OriginalCalories { get; set; }  // The original number of calories. This is used for resetting calories after scaling.
        public string FoodGroup { get; set; }  // The food group of the ingredient.

        // Method to get user input for ingredients
        public List<Ingredients> GetIngredients()
        {
            bool inputValid = false;  // Boolean to check if the user's input is valid
            List<Ingredients> ing = new List<Ingredients>();  // List to store ingredients

            while (!inputValid)
            {
                try
                {
                    // Prompt the user to enter the total number of ingredients
                    Console.Write("\n\nPlease enter the total number of ingredients that will be used: ");
                    int NumIngredients = Convert.ToInt32(Console.ReadLine());

                    // Validate the number of ingredients
                    if (NumIngredients <= 0 || NumIngredients > 1000000000)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\n\nPlease enter a valid number!\n");
                        Console.ResetColor();
                        continue;
                    }

                    // Loop through the array and prompt the user to enter the details of each ingredient
                    for (int i = 0; i < NumIngredients; i++)
                    {
                        string name = null;
                        double quantity = 0;
                        double calories = 0;
                        string measurement = null;
                        string foodGroup = null;

                        // Loop until all fields are filled correctly
                        while (name == null || quantity == 0 || calories == 0 || measurement == null || foodGroup == null)
                        {
                            try
                            {
                                if (name == null)
                                {
                                    Console.Write("\nPlease enter the name of ingredient " + (i + 1) + ": ");
                                    name = Console.ReadLine();
                                }

                                if (measurement == null)
                                {
                                    Console.Write("\nPlease enter the unit of measurement that will be used for ingredient " + (i + 1) + " (tablespoons, teaspoons, litres, etc.): ");
                                    measurement = Console.ReadLine();
                                }

                                if (quantity == 0)
                                {
                                    Console.Write("\nPlease enter the quantity of measurements for ingredient " + (i + 1) + ": ");
                                    quantity = Convert.ToDouble(Console.ReadLine());
                                }

                                if (calories == 0)
                                {
                                    while (calories == 0)
                                    {
                                        Console.Write("\nPlease enter the number of calories for ingredient " + (i + 1) + ": ");
                                        calories = Convert.ToDouble(Console.ReadLine());
                                    }
                                }

                                if (foodGroup == null)
                                {
                                    Console.Write("\nPlease enter the food group for ingredient " + (i + 1) + " (fruit, vegetable, grain, protein, dairy, fat): ");
                                    foodGroup = Console.ReadLine();
                                }
                            }
                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\n\nPlease enter a valid number!\n");
                                Console.ResetColor();
                            }
                        }

                        // Create a new Ingredients object with the entered details and add it to the list
                        Ingredients ingredient = new Ingredients
                        {
                            IngName = name,
                            IngQuantity = quantity,
                            IngUnitOfMeasure = measurement,
                            OriginalIngQuantity = quantity,
                            OriginalIngUnitOfMeasure = measurement,
                            Calories = calories,
                            OriginalCalories = calories,
                            FoodGroup = foodGroup
                        };
                        ing.Add(ingredient);
                    }

                    // Display a success message and return the list of Ingredients objects
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\nIngredients successfully saved!\n\n");
                    Console.ResetColor();
                    return ing;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n\nPlease enter a number!\n");
                    Console.ResetColor();
                }
            }

            // If the user didn't enter a valid number of ingredients, return null
            return null;
        }
    }
}

//-----------------------------------------------------------------------------END OF FILE-----------------------------------------------------------------------------