// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References: List of references:
//             https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/
//             https://youtu.be/QqWfw_CFR6Q?si=OWgC9KPJosQBqu5V
//             https://youtu.be/IHMmPVEOT64?si=FN64GWD1dU8C1i4E
//             https://stackoverflow.com/questions/72696/which-is-generally-best-to-use-stringcomparison-ordinalignorecase-or-stringcom
//             GitHub Copilot for assisting with the structure of the code and helping me find and fix errors.
//             Microsoft Copilot for assisting me with finding and fixing errors in the code.

using System;
using System.Collections.Generic;
using System.Linq;

namespace ST10256859_PROG6221_POE_PART1.Classes
{
    // This class is responsible for displaying the recipe, displaying the menu, and handling the main menu.
    public class RecipeProcesses
    {
        // Creating an instance of the Ingredients class
        private Ingredients ing = new Ingredients();

        // Creating an instance of the Steps class
        private Steps stp = new Steps();

        // Creating an instance of the AlteringRecipeProcesses class
        private AlteringRecipeProcesses altRecipe = new AlteringRecipeProcesses();

        // Creating a list of Recipe objects
        private List<Recipe> recipes = new List<Recipe>();

        // Method to allow the user to enter a new recipe.
        public void EnterNewRecipe()
        {
            // Prompt the user to enter the name of the recipe.
            Console.Write("\nEnter the name of the recipe: ");
            string recipeName = Console.ReadLine();

            // Get ingredients and steps for the recipe.
            Ingredients[] ingredients = GetIngredients();
            Steps[] steps = GetSteps();

            // Convert arrays to lists.
            List<Ingredients> ingredientList = new List<Ingredients>(ingredients);
            List<Steps> stepList = new List<Steps>(steps);

            // Create a new recipe object and add it to the recipes list.
            Recipe recipe = new Recipe(recipeName, ingredientList, stepList);
            recipes.Add(recipe);
        }

        // Method to display all recipes in alphabetical order.
        public void DisplayAllRecipes()
        {
            if (recipes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo recipes found.\n");
                Console.ResetColor();
                return;
            }

            var sortedRecipes = recipes.OrderBy(r => r.RecipeName);

            Console.WriteLine("\nRecipes:");
            foreach (var recipe in sortedRecipes)
            {
                Console.WriteLine(recipe.RecipeName);
            }
        }

        // Method to select a recipe to display.
        private void SelectRecipeToDisplay()
        {
            Console.Write("\nEnter the name of the recipe you want to display: ");
            string recipeName = Console.ReadLine();

            Recipe recipe = recipes.Find(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (recipe == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nRecipe not found.\n");
                Console.ResetColor();
            }
            else
            {
                DisplayRecipe(recipe);
            }
        }

        // Method to notify the user when calories exceed 300.
        private void CaloriesExceeded(Recipe recipe)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\nWarning: Total calories exceed 300!");
            Console.ResetColor();
        }

        // This is the DisplayRecipe method of the AlteringRecipeProcesses class.
        // It takes two parameters: an array of Ingredients objects and an array of Steps objects.
        public void DisplayRecipe(Ingredients[] ing, Steps[] steps)
        {
            // Checking if the ingredients and steps arrays are not null and have a length greater than 0
            if (ing != null && ing.Length > 0 && steps != null && steps.Length > 0)
            {
                // Promps user with the Recipe title
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n\n\n****************************");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("          RECIPE            ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("****************************");
                Console.ForegroundColor = ConsoleColor.Yellow;

                // Display the ingredients section title.
                Console.WriteLine("Ingredients:");

                // Loop through the array of Ingredients objects and display each one.
                for (int i = 0; i < ing.Length; i++)
                {
                    // Display the quantity, unit of measure, and name of the ingredient.
                    Console.WriteLine("~ " + ing[i].IngQuantity + " " + ing[i].IngUnitOfMeasure + " " + ing[i].IngName);
                }

                // Display the steps section title.
                Console.WriteLine("\nSteps:");

                // Loop through the array of Steps objects and display each one.
                for (int i = 0; i < steps.Length; i++)
                {
                    // Display the step number and description.
                    Console.WriteLine("Step " + (i + 1) + ") " + steps[i].StepDescription);
                }

                // Display total calories of recipe.
                Console.WriteLine($"Total Calories: {recipe.TotalCalories}");

                // Check if total calories exceed 300 and notify user.
                if (recipe.TotalCalories > 300)
                {
                    NotifyCaloriesExceeded(recipe);
                }

                // Set the console text color back to magenta and display the end of the recipe.
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("****************************\n\n");

                // Reset the console text color to the default.
                Console.ResetColor();
            }
            else
            {
                // If there are no ingredients or steps to display, inform the user.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nThere is no recipe to display. Please enter a new recipe first!\n\n");
                Console.ResetColor();
            }
        }

        // This is the MainMenu method of my AlteringRecipeProcesses class.
        public void MainMenu()
        {
            // Initialize an empty array of Ingredients objects.
            Ingredients[] ing = new Ingredients[0];

            // Initialize an empty array of Steps objects.
            Steps[] stp = new Steps[0];

            // Declare a variable to store the user's menu choice.
            int choice;

            // Start an infinite loop to display the menu until the user chooses to exit.
            while (true)
            {
                try
                {
                    // Display the menu options.
                    Console.WriteLine("\n****************************");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("            MENU            ");
                    Console.ResetColor();
                    Console.WriteLine("****************************");
                    Console.WriteLine("1) Enter a new recipe");
                    Console.WriteLine("2) Display recipe");
                    Console.WriteLine("3) Scale recipe");
                    Console.WriteLine("4) Reset quantities");
                    Console.WriteLine("5) Clear all data");
                    Console.WriteLine("6) Display all recipes");
                    Console.WriteLine("7) Select what recipe to display");
                    Console.WriteLine("8) Exit");
                    Console.WriteLine("****************************");

                    // Prompt the user to enter their choice.
                    Console.Write("Enter your choice: ");

                    // Try to convert the user's input to an integer.
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    // If the user's input is not a valid integer, display an error message and continue with the next iteration of the loop.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nPlease enter a number that correlates to the menu!\n");
                    Console.ResetColor();
                    continue;
                }

                // Perform an action based on the user's choice.
                if (choice == 1)
                {
                    // If the user chose option 1, prompt them to enter a new recipe.
                    ing = this.ing.GetIngredients();
                    stp = this.stp.GetSteps();
                }
                else if (choice == 2)
                {
                    // If the user chose option 2, display the current recipe.
                    DisplayRecipe(ing, stp);
                }
                else if (choice == 3)
                {
                    // If the user chose option 3, scale the current recipe.
                    // If there's no recipe to scale, display an error message and continue with the next iteration of the loop.
                    if (ing.Length == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nThere is no recipe to scale. Please enter a new recipe first!\n\n");
                        Console.ResetColor();
                        continue;
                    }

                    // Prompt the user to enter a scale factor until they enter a valid one.
                    while (true)
                    {
                        Console.Write("\n\nPlease enter the number you would like to scale the recipe by (Put in '0,5' for half, '2' for double or '3' for triple): ");
                        try
                        {
                            // Try to convert the user's input to a double.
                            double factor = Convert.ToDouble(Console.ReadLine());

                            // If the scale factor is not one of the allowed values, display an error message and continue with the next iteration of the loop.
                            if (factor != 0.5 && factor != 2 && factor != 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\n\nInvalid input. Please enter '0,5' for half, '2' for double, or '3' for triple.\n\n");
                                Console.ResetColor();
                                continue;
                            }

                            // If the scale factor is valid, scale the recipe and break out of the loop.
                            altRecipe.ScaleRecipe(ing, factor);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n\n\nRecipe successfully scaled! View changes by going into the 'Display recipe section'\n\n");
                            Console.ResetColor();
                            break;
                        }
                        catch (FormatException)
                        {
                            // If the user's input is not a valid number, display an error message and continue with the next iteration of the loop.
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\n\nInvalid input. Please enter '0,5' for half, '2' for double, or '3' for triple.\n\n");
                            Console.ResetColor();
                        }
                    }
                }
                // If the user chose option 4, reset the quantities of the ingredients.
                else if (choice == 4)
                {
                    // If there's no recipe to reset, display an error message and continue with the next iteration of the loop.
                    if (ing.Length == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nThere is no recipe to reset. Please enter a new recipe first!\n\n");
                        Console.ResetColor();
                        continue;
                    }

                    // Ask the user to confirm that they want to reset the quantities.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\n\nAre you sure you want to reset all quantities? (y/n): ");
                    Console.ResetColor();
                    string confirm = Console.ReadLine();

                    // If the user confirmed, reset the quantities and display a success message.
                    if (confirm.Equals("yes", StringComparison.OrdinalIgnoreCase) || confirm.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        altRecipe.ResetNewQuantities(ing);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\n\nQuantities successfully reset!\n\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        // If the user didn't confirm, display a cancellation message.
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nResetting quantities cancelled.\n");
                        Console.ResetColor();
                    }
                }
                // If the user chose option 5, clear all recipe data.
                else if (choice == 5)
                {
                    // If there's no recipe to clear, display an error message and continue with the next iteration of the loop.
                    if (ing.Length == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nThere is no recipe to clear. Please enter a new recipe first!\n\n");
                        Console.ResetColor();
                        continue;
                    }

                    // Ask the user to confirm that they want to clear all recipe data.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\n\nAre you sure you want to clear all recipe data? (y/n): ");
                    Console.ResetColor();
                    string confirm = Console.ReadLine();

                    // If the user confirmed, clear all recipe data and display a success message.
                    if (confirm.Equals("yes", StringComparison.OrdinalIgnoreCase) || confirm.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        altRecipe.ClearAllData();
                        ing = new Ingredients[0];
                        stp = new Steps[0];
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\n\nRecipe data successfully cleared!\n\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        // If the user didn't confirm, display a cancellation message.
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nData clearing cancelled.\n");
                        Console.ResetColor();
                    }
                }

                else if (choice == 6)
                {
                    DisplayAllRecipes();
                    continue;
                }

                else if (choice == 7)
                {
                    SelectRecipeToDisplay();
                    continue;
                }
                // If the user chose option 8, exit the program.
                else if (choice == 8)
                {
                    return;
                }
                else
                {
                    // If the user entered a number that doesn't correspond to any menu option, display an error message and continue with the next iteration of the loop.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nPlease enter a number that correlates to the menu!\n");
                    Console.ResetColor();
                    continue;
                }
            }
        }
    }
}

//-----------------------------------------------------------------------------END OF FILE-----------------------------------------------------------------------------