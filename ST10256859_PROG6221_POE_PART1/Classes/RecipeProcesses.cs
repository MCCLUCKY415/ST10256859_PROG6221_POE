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
    public delegate void CaloriesExceededHandler(Recipe recipe);

    public class RecipeProcesses
    {
        private Ingredients ing = new Ingredients();
        private Steps stp = new Steps();
        private AlteringRecipeProcesses altRecipe = new AlteringRecipeProcesses();
        private List<Recipe> recipes = new List<Recipe>();
        private List<Ingredients> ingredients = new List<Ingredients>();
        private List<Steps> steps = new List<Steps>();

        public event CaloriesExceededHandler CaloriesExceededEvent;

        public RecipeProcesses()
        {
            CaloriesExceededEvent += CaloriesExceeded;
        }

        public void EnterNewRecipe()
        {
            Console.Write("\nEnter the name of the recipe: ");
            string recipeName = Console.ReadLine();

            ingredients = GetIngredients();
            steps = GetSteps();

            Recipe recipe = new Recipe(recipeName, ingredients, steps);
            recipes.Add(recipe);

            if (recipe.TotalCalories > 300)
            {
                OnCaloriesExceeded(recipe);
            }
        }

        private void CaloriesExceeded(Recipe recipe)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\nWarning: Total calories exceed 300!");
            Console.ResetColor();
        }

        private void OnCaloriesExceeded(Recipe recipe)
        {
            CaloriesExceededEvent?.Invoke(recipe);
        }

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
                DisplayRecipe(recipe.Ingredients, recipe.Steps);
            }
        }

        private List<Ingredients> GetIngredients()
        {
            List<Ingredients> ingredientsList = new List<Ingredients>();

            bool inputValid = false;

            while (!inputValid)
            {
                try
                {
                    Console.Write("\n\nPlease enter the total number of ingredients that will be used: ");
                    int numIngredients = Convert.ToInt32(Console.ReadLine());

                    if (numIngredients <= 0 || numIngredients > 1000000000)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nPlease enter a valid number!");
                        Console.ResetColor();
                        continue;
                    }

                    for (int i = 0; i < numIngredients; i++)
                    {
                        Console.Write("\nPlease enter the name of ingredient " + (i + 1) + ": ");
                        string name = Console.ReadLine();

                        Console.Write("\nPlease enter the unit of measurement that will be used for ingredient " + (i + 1) + " (tablespoons, teaspoons, litres, etc.): ");
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
                            }
                        }

                        Console.Write("Please enter the number of calories for ingredient " + (i + 1) + ": ");
                        double calories = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Please enter the food group for ingredient " + (i + 1) + " (fruit, vegetable, grain, protein, dairy, fat): ");
                        string foodGroup = Console.ReadLine();

                        Ingredients ingredient = new Ingredients
                        {
                            IngName = name,
                            IngQuantity = quantity,
                            IngUnitOfMeasure = measurement,
                            OriginalIngQuantity = quantity,
                            OriginalIngUnitOfMeasure = measurement,
                            Calories = calories,
                            FoodGroup = foodGroup
                        };

                        ingredientsList.Add(ingredient);
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\nIngredients successfully saved!\n\n");
                    Console.ResetColor();

                    inputValid = true;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nPlease enter a number!\n");
                    Console.ResetColor();
                }
            }

            return ingredientsList;
        }

        private List<Steps> GetSteps()
        {
            List<Steps> stepsList = new List<Steps>();

            bool inputValid = false;

            while (!inputValid)
            {
                try
                {
                    Console.Write("\n\nPlease enter the total number of steps that will be used: ");
                    int numSteps = Convert.ToInt32(Console.ReadLine());

                    if (numSteps <= 0 || numSteps > 1000000000)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nPlease enter a valid number!");
                        Console.ResetColor();
                        continue;
                    }

                    for (int i = 0; i < numSteps; i++)
                    {
                        Console.Write("\nPlease enter the description of step " + (i + 1) + ": ");
                        string description = Console.ReadLine();

                        Steps step = new Steps
                        {
                            NumSteps = i + 1,
                            StepDescription = description
                        };

                        stepsList.Add(step);
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\nSteps successfully saved!\n\n");
                    Console.ResetColor();

                    inputValid = true;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nPlease enter a number!\n");
                    Console.ResetColor();
                }
            }

            return stepsList;
        }

        public void DisplayRecipe(List<Ingredients> ing, List<Steps> steps)
        {
            if (ing != null && ing.Count > 0 && steps != null && steps.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n\n\n****************************");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("          RECIPE            ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("****************************");
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("Ingredients:");

                foreach (var ingredient in ing)
                {
                    Console.WriteLine($"~ {ingredient.IngQuantity} {ingredient.IngUnitOfMeasure} {ingredient.IngName}");
                }

                Console.WriteLine("\nSteps:");

                foreach (var step in steps)
                {
                    Console.WriteLine("Step " + (step.NumSteps) + " " + (step.StepDescription));
                }

                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nThere is no recipe to display. Please enter a new recipe first!\n\n");
                Console.ResetColor();
            }
        }


        public void MainMenu()
        {
            int choice;

            while (true)
            {
                try
                {
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

                    Console.Write("Enter your choice: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nPlease enter a number that correlates to the menu!\n");
                    Console.ResetColor();
                    continue;
                }

                if (choice == 1)
                {
                    EnterNewRecipe();
                }
                else if (choice == 2)
                {
                    DisplayRecipe(ingredients, steps);
                }
                else if (choice == 3)
                {
                    if (ingredients.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nThere is no recipe to scale. Please enter a new recipe first!\n\n");
                        Console.ResetColor();
                        continue;
                    }

                    while (true)
                    {
                        Console.Write("\n\nPlease enter the number you would like to scale the recipe by (Put in '0,5' for half, '2' for double or '3' for triple): ");
                        try
                        {
                            double factor = Convert.ToDouble(Console.ReadLine());

                            if (factor != 0.5 && factor != 2 && factor != 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\n\nInvalid input. Please enter '0,5' for half, '2' for double, or '3' for triple.\n\n");
                                Console.ResetColor();
                                continue;
                            }

                            altRecipe.ScaleRecipe(ingredients, factor);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n\n\nRecipe successfully scaled! View changes by going into the 'Display recipe section'\n\n");
                            Console.ResetColor();
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\n\nInvalid input. Please enter '0,5' for half, '2' for double, or '3' for triple.\n\n");
                            Console.ResetColor();
                        }
                    }
                }
                else if (choice == 4)
                {
                    if (ingredients.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nThere is no recipe to reset. Please enter a new recipe first!\n\n");
                        Console.ResetColor();
                        continue;
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\n\nAre you sure you want to reset all quantities? (y/n): ");
                    Console.ResetColor();
                    string confirm = Console.ReadLine();

                    if (confirm.Equals("yes", StringComparison.OrdinalIgnoreCase) || confirm.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        altRecipe.ResetNewQuantities(ingredients);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\n\nQuantities successfully reset!\n\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nResetting quantities cancelled.\n");
                        Console.ResetColor();
                    }
                }
                else if (choice == 5)
                {
                    if (ingredients.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nThere is no recipe to clear. Please enter a new recipe first!\n\n");
                        Console.ResetColor();
                        continue;
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\n\nAre you sure you want to clear all recipe data? (y/n): ");
                    Console.ResetColor();
                    string confirm = Console.ReadLine();

                    if (confirm.Equals("yes", StringComparison.OrdinalIgnoreCase) || confirm.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        altRecipe.ClearAllData();
                        ingredients.Clear();
                        steps.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\n\nRecipe data successfully cleared!\n\n");
                        Console.ResetColor();
                    }
                    else
                    {
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
                else if (choice == 8)
                {
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nPlease enter a number that correlates to the menu!\n");
                    Console.ResetColor();
                    continue;
                }
            }
        }
    }
}
