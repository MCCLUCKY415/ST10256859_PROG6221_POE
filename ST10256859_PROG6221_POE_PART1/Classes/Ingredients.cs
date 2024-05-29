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
using System.Collections.Generic;
using System.Linq;

namespace ST10256859_PROG6221_POE_PART1.Classes
{
    // This class is responsible for handling the ingredients of a recipe.
    public class Ingredients
    {
        // Declare properties for the Ingredients class.
        public string IngName { get; set; }  // The name of the ingredient.
        public string IngUnitOfMeasure { get; set; }  // The unit of measurement for the ingredient (e.g., tablespoons, teaspoons, litres, etc.).
        public double IngQuantity { get; set; }  // The quantity of the ingredient.
        public double OriginalIngQuantity { get; set; }  // The original quantity of the ingredient. This is used for resetting quantities after scaling.
        public int NumIngredients { get; set; } = 0;  // The total number of ingredients. This is used for creating an array of Ingredients objects.
        public string OriginalIngUnitOfMeasure { get; set; }  // The original unit of measurement for the ingredient. This is used for resetting units of measurement after scaling.
        public double Calories { get; set; }  // The number of calories.
        public string FoodGroup { get; set; }  // The food group of the ingredient.

        // This is the GetIngredients method of the Ingredients class.
        public List<Ingredients> GetIngredients()
        {
            // Declare a boolean variable to check if the user's input is valid.
            bool inputValid = false;

            // Start a loop to prompt the user for input until they enter a valid number of ingredients.
            while (!inputValid)
            {
                // The try block contains code that might throw an exception.
                try
                {
                    // Prompt the user to enter the total number of ingredients.
                    Console.Write("\n\nPlease enter the total number of ingredients that will be used: ");

                    // Try to convert the user's input to an integer.
                    NumIngredients = Convert.ToInt32(Console.ReadLine());

                    // If the number of ingredients is not within a reasonable range, display an error message and continue with the next iteration of the loop.
                    if (NumIngredients <= 0 || NumIngredients > 1000000000)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nPlease enter a valid number!");
                        Console.ResetColor();
                        continue;
                    }

                    // If the number of ingredients is valid, exit the loop.
                    inputValid = true;
                }
                // The catch block contains code to handle the exception.
                catch (FormatException)
                {
                    // If the user's input is not a valid integer, display an error message and continue with the next iteration of the loop.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nPlease enter a number!");
                    Console.ResetColor();
                    continue;
                }

                // Create an array of Ingredients objects with a size equal to the number of ingredients.
                Ingredients[] ing = new Ingredients[NumIngredients];

                // Loop through the array and prompt the user to enter the details of each ingredient.
                for (int i = 0; i < NumIngredients; i++)
                {
                    // Prompt the user to enter the name of the ingredient.
                    Console.Write("\nPlease enter the name of ingredient " + (i + 1) + ": ");
                    string name = Console.ReadLine();

                    // Prompt the user to enter the unit of measurement for the ingredient.
                    Console.Write("\nPlease enter the unit of measurement that will be used for ingredient " + (i + 1) + " (tablespoons, teaspoons, litres, etc.): ");
                    string measurement = Console.ReadLine();

                    // Declare a variable to store the quantity of the ingredient and a boolean variable to check if the quantity is valid.
                    double quantity = 0;
                    bool quantityValid = false;

                    // Start a loop to prompt the user for the quantity of the ingredient until they enter a valid quantity.
                    while (!quantityValid)
                    {
                        // The try block contains code that might throw an exception.
                        try
                        {
                            // Prompt the user to enter the quantity of the ingredient.
                            Console.Write("\nPlease enter the quantity of measurements for ingredient " + (i + 1) + ": ");

                            // Try to convert the user's input to a double.
                            quantity = Convert.ToDouble(Console.ReadLine());

                            // If the quantity is not within a reasonable range, display an error message and continue with the next iteration of the loop.
                            if (quantity <= 0 || quantity > 1000000000)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\nPlease enter a valid number!\n");
                                Console.ResetColor();
                                continue;
                            }

                            // If the quantity is valid, exit the loop.
                            quantityValid = true;
                        }
                        // The catch block contains code to handle the exception.
                        catch (FormatException)
                        {
                            // If the user's input is not a valid number, display an error message and continue with the next iteration of the loop.
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\nPlease enter a number!\n");
                            Console.ResetColor();
                            continue;
                        }
                    }

                    // Prompt the user to enter the number of calories for the ingredient.
                    Console.Write("Please enter the number of calories for ingredient " + (i + 1) + ": ");
                    double calories = Convert.ToDouble(Console.ReadLine());

                    // Prompt the user to enter the food group for the ingredient.
                    Console.Write("Please enter the food group for ingredient " + (i + 1) + " (fruit, vegetable, grain, protein, dairy, fat): ");
                    string foodGroup = Console.ReadLine();

                    // Create a new Ingredients object with the entered details and add it to the array.
                    ing[i] = new Ingredients { IngName = name, IngQuantity = quantity, IngUnitOfMeasure = measurement, OriginalIngQuantity = quantity, OriginalIngUnitOfMeasure = measurement, Calories = calories, FoodGroup = foodGroup };
                }

                // Display a success message and return the array of Ingredients objects.
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\nIngredients successfully saved!\n\n");
                Console.ResetColor();
                return ing.ToList();
            }

            // If the user didn't enter a valid number of ingredients, return null.
            return null;
        }
    }
}

//-----------------------------------------------------------------------------END OF FILE-----------------------------------------------------------------------------