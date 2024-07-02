//// Dhiren Ruthenavelu
//// ST10256859
//// Group 2

//// References: List of references:
////             https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/
////             https://youtu.be/QqWfw_CFR6Q?si=OWgC9KPJosQBqu5V
////             https://youtu.be/IHMmPVEOT64?si=FN64GWD1dU8C1i4E
////             https://stackoverflow.com/questions/72696/which-is-generally-best-to-use-stringcomparison-ordinalignorecase-or-stringcom
////             GitHub Copilot for assisting with the structure of the code and helping me find and fix errors.
////             Microsoft Copilot for assisting me with finding and fixing errors in the code.

//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace ST10256859_PROG6221_POE_PART1.Classes
//{
//    // Delegate for handling the event when total calories exceed a certain limit.
//    public delegate void CaloriesExceeded(Recipe recipe);

//    // Main class for handling recipe processes.
//    public class RecipeProcesses
//    {
//        // Instances for handling Ingredient, Steps, and recipe alteration.
//        private Ingredient ing = new Ingredients();
//        private Steps stp = new Steps();
//        private AlteringRecipeProcesses altRecipe = new AlteringRecipeProcesses();

//        // List to store multiple recipes and the currently selected recipe.
//        private List<Recipe> recipes = new List<Recipe>();
//        private Recipe currentRecipe = null;

//        // Event for handling when total calories exceed a certain limit.
//        public event CaloriesExceeded CaloriesExceededEvent;

//        // Constructor to initialize the event handler for calories exceeded.
//        public RecipeProcesses()
//        {
//            CaloriesExceededEvent += CaloriesExceeded;
//        }

//        // Method to enter a new recipe into the system.
//        public void EnterNewRecipe()
//        {
//            List<Ingredient> newIngredients = new List<Ingredient>();
//            List<Steps> newSteps = new List<Steps>();

//            string recipeName = string.Empty;

//            // Prompt the user to enter the name of the recipe, ensuring it's not empty.
//            while (string.IsNullOrWhiteSpace(recipeName))
//            {
//                Console.Write("\n\nEnter the name of the recipe: ");
//                recipeName = Console.ReadLine();

//                if (string.IsNullOrWhiteSpace(recipeName))
//                {
//                    Console.ForegroundColor = ConsoleColor.Red;
//                    Console.WriteLine("\n\n\nPlease enter a valid recipe name!\n");
//                    Console.ResetColor();
//                }
//            }

//            // Get ingredients and steps for the recipe.
//            newIngredients = GetIngredients();
//            newSteps = GetSteps();

//            // Create a new Recipe object and add it to the recipes list.
//            Recipe recipe = new Recipe(recipeName, newIngredients, newSteps);
//            recipes.Add(recipe);
//        }

//        // Event handler for when total calories exceed 300.
//        private void CaloriesExceeded(Recipe recipe)
//        {
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.WriteLine("\n\n\n\nWarning: Total calories exceed 300!\n");
//            Console.ResetColor();
//        }

//        // Method to invoke the CaloriesExceededEvent event.
//        private void WhenCaloriesExceed(Recipe recipe)
//        {
//            CaloriesExceededEvent?.Invoke(recipe);
//        }

//        // Method to display all recipes stored in the system.
//        public void DisplayAllRecipes()
//        {
//            if (recipes.Count == 0)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("\n\n\nNo recipes found.\n\n");
//                Console.ResetColor();
//                return;
//            }

//            // Sort recipes by recipe name.
//            var sortedRecipes = recipes.OrderBy(r => r.RecipeName);

//            // Display the header for the recipes.
//            Console.ForegroundColor = ConsoleColor.Magenta;
//            Console.WriteLine("\n\n\n********************************");
//            Console.ForegroundColor = ConsoleColor.Blue;
//            Console.WriteLine("            RECIPES              ");
//            Console.ForegroundColor = ConsoleColor.Magenta;
//            Console.WriteLine("********************************");
//            Console.ResetColor();

//            // Display each recipe name.
//            Console.ForegroundColor = ConsoleColor.Yellow;
//            foreach (var recipe in sortedRecipes)
//            {
//                Console.WriteLine("~ " + (recipe.RecipeName));
//            }
//            Console.ResetColor();

//            // Display the footer for the recipes.
//            Console.ForegroundColor = ConsoleColor.Magenta;
//            Console.WriteLine("********************************\n\n");
//            Console.ResetColor();
//        }

//        // Method to select and display a specific recipe.
//        private void SelectRecipeToDisplay()
//        {
//            Console.Write("\n\nEnter the name of the recipe you want to display: ");
//            string recipeName = Console.ReadLine();

//            // Find the selected recipe by its name (case insensitive).
//            Recipe selectedRecipe = recipes.Find(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

//            if (selectedRecipe == null)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("\n\n\nRecipe not found.\n\n");
//                Console.ResetColor();
//            }
//            else
//            {
//                // Display the selected recipe.
//                DisplayRecipe(selectedRecipe);
//                currentRecipe = selectedRecipe;
//            }
//        }

//        // Method to get ingredients for a new recipe.
//        private List<Ingredient> GetIngredients()
//        {
//            List<Ingredient> ingredientsList = new List<Ingredient>();
//            double totalCalories = 0;

//            bool inputValid = false;

//            // Loop until valid input is provided for the number of ingredients.
//            while (!inputValid)
//            {
//                try
//                {
//                    Console.Write("\n\nPlease enter the total number of ingredients that will be used: ");
//                    int numIngredients = Convert.ToInt32(Console.ReadLine());

//                    if (numIngredients <= 0 || numIngredients > 1000000000)
//                    {
//                        Console.ForegroundColor = ConsoleColor.Red;
//                        Console.WriteLine("\n\nPlease enter a valid number!");
//                        Console.ResetColor();
//                        continue;
//                    }

//                    // Loop to input details for each ingredient.
//                    for (int i = 0; i < numIngredients; i++)
//                    {
//                        Console.Write("\n\nPlease enter the name of ingredient " + (i + 1) + ": ");
//                        string name = Console.ReadLine();

//                        Console.Write("\n\nPlease enter the unit of measurement that will be used for ingredient " + (i + 1) + " (tablespoons, teaspoons, litres, etc.): ");
//                        string measurement = Console.ReadLine();

//                        double quantity = 0;
//                        bool quantityValid = false;

//                        // Loop until valid input is provided for the quantity.
//                        while (!quantityValid)
//                        {
//                            try
//                            {
//                                Console.Write("\n\nPlease enter the quantity of measurements for ingredient " + (i + 1) + ": ");
//                                quantity = Convert.ToDouble(Console.ReadLine());

//                                if (quantity <= 0 || quantity > 1000000000)
//                                {
//                                    Console.ForegroundColor = ConsoleColor.Red;
//                                    Console.WriteLine("\n\nPlease enter a valid number!\n");
//                                    Console.ResetColor();
//                                    continue;
//                                }

//                                quantityValid = true;
//                            }
//                            catch (FormatException)
//                            {
//                                Console.ForegroundColor = ConsoleColor.Red;
//                                Console.WriteLine("\n\nPlease enter a number!\n");
//                                Console.ResetColor();
//                            }
//                        }

//                        double calories = 0;
//                        bool caloriesValid = false;

//                        // Loop until valid input is provided for the calories.
//                        while (!caloriesValid)
//                        {
//                            try
//                            {
//                                //Explanation on calories.
//                                Console.ForegroundColor = ConsoleColor.Yellow;
//                                Console.WriteLine("\n\nCalories: They are units of energy that indicate how much energy food provides to the body. They are essential for fueling bodily functions and activities.");
//                                Console.ResetColor();
//                                Console.Write("\n\nPlease enter the number of calories for ingredient " + (i + 1) + ": ");
//                                calories = Convert.ToDouble(Console.ReadLine());

//                                if (calories <= 0 || calories > 1000000000)
//                                {
//                                    Console.ForegroundColor = ConsoleColor.Red;
//                                    Console.WriteLine("\n\nPlease enter a valid number!\n");
//                                    Console.ResetColor();
//                                    continue;
//                                }

//                                caloriesValid = true;
//                            }
//                            catch (FormatException)
//                            {
//                                Console.ForegroundColor = ConsoleColor.Red;
//                                Console.WriteLine("\n\nPlease enter a number!\n");
//                                Console.ResetColor();
//                            }
//                        }

//                        //Explanation on different food groups.
//                        Console.ForegroundColor = ConsoleColor.Yellow;
//                        Console.WriteLine("\n\nFruits - They are food rich in vitamins, minerals, and fiber, providing essential nutrients and antioxidants to support overall health.\n");

//                        Console.WriteLine("Vegetables - They are food packed with vitamins, minerals, and fiber, promoting good digestion and reducing the risk of chronic diseases.\n");

//                        Console.WriteLine("Grains - Grains, especially whole grains, are a major source of energy and provide essential nutrients like fiber, iron, and B vitamins.\n");

//                        Console.WriteLine("Proteins - Include meat, poultry, fish, beans, and nuts, are vital for building and repairing tissues and supporting immune function.\n");

//                        Console.WriteLine("Dairy - Are products like milk, cheese, and yogurt are rich in calcium, vitamin D, and other nutrients important for bone health.\n");

//                        Console.WriteLine("Fats and Oils - Are healthy fats and oils, such as those from avocados, nuts, and olive oil, are crucial for brain health and the absorption of fat-soluble vitamins.\n");
//                        Console.ResetColor();
//                        Console.Write("\n\nPlease enter the food group for ingredient " + (i + 1) + " (fruits, vegetables, grains, proteins, dairy, fats/oils): ");
//                        string foodGroup = Console.ReadLine();

//                        // Create an Ingredient object and add it to the list.
//                        Ingredient ingredient = new Ingredients
//                        {
//                            IngName = name,
//                            IngQuantity = quantity,
//                            IngUnitOfMeasure = measurement,
//                            OriginalIngQuantity = quantity,
//                            OriginalIngUnitOfMeasure = measurement,
//                            Calories = calories,
//                            FoodGroup = foodGroup
//                        };

//                        ingredientsList.Add(ingredient);

//                        totalCalories += calories;

//                        // Display a warning if total calories exceed 300.
//                        if (totalCalories >= 301)
//                        {
//                            Console.ForegroundColor = ConsoleColor.Red;
//                            Console.WriteLine("\n\nWarning: Total calories exceed 300!");
//                            Console.ResetColor();
//                        }
//                    }

//                    Console.ForegroundColor = ConsoleColor.Green;
//                    Console.WriteLine("\n\n\nIngredients successfully saved!\n\n");
//                    Console.ResetColor();

//                    inputValid = true;
//                }
//                catch (FormatException)
//                {
//                    Console.ForegroundColor = ConsoleColor.Red;
//                    Console.WriteLine("\n\nPlease enter a number!\n");
//                    Console.ResetColor();
//                }
//            }

//            return ingredientsList;
//        }

//        // Method to get steps for a new recipe.
//        private List<Steps> GetSteps()
//        {
//            List<Steps> stepsList = new List<Steps>();

//            bool inputValid = false;

//            // Loop until valid input is provided for the number of steps.
//            while (!inputValid)
//            {
//                try
//                {
//                    Console.Write("\n\nPlease enter the total number of steps that will be used: ");
//                    int numSteps = Convert.ToInt32(Console.ReadLine());

//                    if (numSteps <= 0 || numSteps > 1000000000)
//                    {
//                        Console.ForegroundColor = ConsoleColor.Red;
//                        Console.WriteLine("\n\nPlease enter a valid number!");
//                        Console.ResetColor();
//                        continue;
//                    }

//                    // Loop to input details for each step.
//                    for (int i = 0; i < numSteps; i++)
//                    {
//                        Console.Write("\n\nPlease enter the description of step " + (i + 1) + ": ");
//                        string description = Console.ReadLine();

//                        // Create a Steps object and add it to the list.
//                        Steps step = new Steps
//                        {
//                            NumSteps = i + 1,
//                            StepDescription = description
//                        };

//                        stepsList.Add(step);
//                    }

//                    Console.ForegroundColor = ConsoleColor.Green;
//                    Console.WriteLine("\n\n\nSteps successfully saved!\n\n");
//                    Console.ResetColor();

//                    inputValid = true;
//                }
//                catch (FormatException)
//                {
//                    Console.ForegroundColor = ConsoleColor.Red;
//                    Console.WriteLine("\n\nPlease enter a number!\n");
//                    Console.ResetColor();
//                }
//            }

//            return stepsList;
//        }

//        // Method to display the details of a recipe.
//        public void DisplayRecipe(Recipe recipeToDisplay)
//        {
//            if (recipeToDisplay.Ingredients != null && recipeToDisplay.Ingredients.Count > 0 && recipeToDisplay.Steps != null && recipeToDisplay.Steps.Count > 0)
//            {
//                // Display the header for the recipe.
//                Console.ForegroundColor = ConsoleColor.Magenta;
//                Console.WriteLine("\n\n\n********************************");
//                Console.ForegroundColor = ConsoleColor.Blue;
//                Console.WriteLine("            " + recipeToDisplay.RecipeName.ToUpper() + "              ");
//                Console.ForegroundColor = ConsoleColor.Magenta;
//                Console.WriteLine("********************************");
//                Console.ForegroundColor = ConsoleColor.Yellow;

//                // Display ingredients and total calories.
//                Console.WriteLine("Ingredients:");

//                foreach (var ingredient in recipeToDisplay.Ingredients)
//                {
//                    Console.WriteLine("~ " + ingredient.IngQuantity + " " + ingredient.IngUnitOfMeasure + " " + ingredient.IngName);
//                }

//                double totalCalories = recipeToDisplay.CalculateTotalCalories();
//                Console.WriteLine("\n--------------------------------");
//                Console.Write("Total calories: ");

//                // Display total calories in green if under 301, otherwise in red.
//                if (totalCalories >= 301)
//                {
//                    Console.ForegroundColor = ConsoleColor.Red;
//                    Console.WriteLine(totalCalories);
//                    Console.ResetColor();
//                }
//                else
//                {
//                    Console.ForegroundColor = ConsoleColor.Green;
//                    Console.WriteLine(totalCalories);
//                    Console.ResetColor();
//                }

//                Console.ForegroundColor = ConsoleColor.Yellow;
//                Console.WriteLine("--------------------------------");

//                // Display steps.
//                Console.WriteLine("\nSteps:");

//                foreach (var step in recipeToDisplay.Steps)
//                {
//                    Console.WriteLine("Step " + (step.NumSteps) + ": " + (step.StepDescription));
//                }
//                Console.ForegroundColor = ConsoleColor.Magenta;
//                Console.WriteLine("********************************\n\n");
//                Console.ResetColor();
//            }
//            else
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("\n\n\nThere is no recipe to display. Please enter a new recipe first.\n\n\n");
//                Console.ResetColor();
//            }
//        }

//        // Main menu method to interact with the user and handle menu options.
//        public void MainMenu()
//        {
//            int choice;

//            while (true)
//            {
//                try
//                {
//                    // Display the main menu options.
//                    Console.WriteLine("\n********************************");
//                    Console.ForegroundColor = ConsoleColor.Blue;
//                    Console.WriteLine("              MENU              ");
//                    Console.ResetColor();
//                    Console.WriteLine("********************************");
//                    Console.WriteLine("1) Enter a new recipe");
//                    Console.WriteLine("2) Display all recipes");
//                    Console.WriteLine("3) Select what recipe to display");
//                    Console.WriteLine("4) Scale recipe");
//                    Console.WriteLine("5) Reset quantities");
//                    Console.WriteLine("6) Clear all data");
//                    Console.WriteLine("7) Exit");
//                    Console.WriteLine("********************************");

//                    Console.Write("Enter your choice: ");
//                    choice = Convert.ToInt32(Console.ReadLine());
//                }
//                catch (FormatException)
//                {
//                    Console.ForegroundColor = ConsoleColor.Red;
//                    Console.WriteLine("\n\n\nPlease enter a number that correlates to the menu!\n\n");
//                    Console.ResetColor();
//                    continue;
//                }

//                // Handle the user's choice from the main menu.
//                if (choice == 1)
//                {
//                    EnterNewRecipe();
//                }
//                else if (choice == 2)
//                {
//                    DisplayAllRecipes();
//                    continue;
//                }
//                else if (choice == 3)
//                {
//                    SelectRecipeToDisplay();
//                    continue;
//                }
//                else if (choice == 4)
//                {
//                    // Scale the current recipe by a specified factor.
//                    if (currentRecipe == null)
//                    {
//                        Console.ForegroundColor = ConsoleColor.Red;
//                        Console.WriteLine("\n\n\nThere is no recipe to scale. Please enter a new recipe first!\n\n");
//                        Console.ResetColor();
//                        continue;
//                    }

//                    while (true)
//                    {
//                        Console.Write("\n\nPlease enter the number you would like to scale the recipe by (Put in '0,5' for half, '2' for double or '3' for triple): ");
//                        try
//                        {
//                            double factor = Convert.ToDouble(Console.ReadLine());

//                            if (factor != 0.5 && factor != 2 && factor != 3)
//                            {
//                                Console.ForegroundColor = ConsoleColor.Red;
//                                Console.WriteLine("\n\n\nInvalid input. Please enter '0,5' for half, '2' for double, or '3' for triple.\n\n");
//                                Console.ResetColor();
//                                continue;
//                            }

//                            altRecipe.ScaleRecipe(currentRecipe.Ingredients, factor);
//                            currentRecipe.CalculateTotalCalories();
//                            Console.ForegroundColor = ConsoleColor.Green;
//                            Console.WriteLine("\n\n\nRecipe successfully scaled! View changes by going into the 'Select what recipe to display' section\n\n");
//                            Console.ResetColor();
//                            break;
//                        }
//                        catch (FormatException)
//                        {
//                            Console.ForegroundColor = ConsoleColor.Red;
//                            Console.WriteLine("\n\n\nInvalid input. Please enter '0,5' for half, '2' for double, or '3' for triple.\n\n");
//                            Console.ResetColor();
//                        }
//                    }
//                }
//                else if (choice == 5)
//                {
//                    // Reset all ingredient quantities for the current recipe.
//                    if (currentRecipe == null)
//                    {
//                        Console.ForegroundColor = ConsoleColor.Red;
//                        Console.WriteLine("\n\n\nThere is no recipe to reset. Please enter a new recipe first!\n\n");
//                        Console.ResetColor();
//                        continue;
//                    }

//                    Console.ForegroundColor = ConsoleColor.Red;
//                    Console.Write("\n\n\nAre you sure you want to reset all quantities? (y/n): ");
//                    Console.ResetColor();
//                    string confirm = Console.ReadLine();

//                    if (confirm.Equals("yes", StringComparison.OrdinalIgnoreCase) || confirm.Equals("y", StringComparison.OrdinalIgnoreCase))
//                    {
//                        altRecipe.ResetNewQuantities(currentRecipe.Ingredients);
//                        Console.ForegroundColor = ConsoleColor.Green;
//                        Console.WriteLine("\n\nQuantities successfully reset!\n\n");
//                        Console.ResetColor();
//                    }
//                    else
//                    {
//                        Console.ForegroundColor = ConsoleColor.Red;
//                        Console.WriteLine("\n\nResetting quantities cancelled.\n\n");
//                        Console.ResetColor();
//                    }
//                }
//                else if (choice == 6)
//                {
//                    // Clear all data related to the current recipe.
//                    if (currentRecipe == null)
//                    {
//                        Console.ForegroundColor = ConsoleColor.Red;
//                        Console.WriteLine("\n\n\nThere is no recipe to clear. Please enter a new recipe first!\n\n");
//                        Console.ResetColor();
//                        continue;
//                    }

//                    Console.ForegroundColor = ConsoleColor.Red;
//                    Console.Write("\n\n\nAre you sure you want to clear all recipe data? (y/n): ");
//                    Console.ResetColor();
//                    string confirm = Console.ReadLine();

//                    if (confirm.Equals("yes", StringComparison.OrdinalIgnoreCase) || confirm.Equals("y", StringComparison.OrdinalIgnoreCase))
//                    {
//                        altRecipe.ClearAllData();
//                        Console.ForegroundColor = ConsoleColor.Green;
//                        Console.WriteLine("\n\nRecipe data successfully cleared!\n\n");
//                        Console.ResetColor();
//                    }
//                    else
//                    {
//                        Console.ForegroundColor = ConsoleColor.Red;
//                        Console.WriteLine("\n\nData clearing cancelled.\n\n");
//                        Console.ResetColor();
//                    }
//                }
//                else if (choice == 7)
//                {
//                    // Exit the program.
//                    return;
//                }
//                else
//                {
//                    Console.ForegroundColor = ConsoleColor.Red;
//                    Console.WriteLine("\n\n\nPlease enter a number that correlates to the menu!\n\n");
//                    Console.ResetColor();
//                    continue;
//                }
//            }
//        }
//    }
//}
////-----------------------------------------------------------------------------END OF FILE-----------------------------------------------------------------------------