using System;

namespace ST10256859_PROG6221_POE_PART1.Classes
{
    public class RecipeProcesses
    {
        private Ingredients ing = new Ingredients();
        private Steps stp = new Steps();

        public void ScaleRecipe(Ingredients[] ing, double factor)
        {
            if (ing != null && ing.Length > 0)
            {
                foreach (var ingredient in ing)
                {
                    ingredient.IngQuantity = ingredient.OriginalIngQuantity * factor;
                }
            }
            else
            {
                Console.WriteLine("No ingredients to scale. Please enter a new recipe first.");
            }
        }

        public void ResetNewQuantities(Ingredients[] ing)
        {
            if (ing != null && ing.Length > 0)
            {
                foreach (var ingredient in ing)
                {
                    ingredient.IngQuantity = ingredient.OriginalIngQuantity;
                }
            }
            else
            {
                Console.WriteLine("No ingredients to reset. Please enter a new recipe first.");
            }
        }

        public void ClearAllData()
        {
            ing = new Ingredients();
            stp = new Steps();
        }

        public void DisplayRecipe(Ingredients[] ing, Steps[] steps)
        {
            if (ing != null && ing.Length > 0 && steps != null && steps.Length > 0)
            {
                Console.WriteLine("\n          RECIPE            ");
                Console.WriteLine("****************************");
                Console.WriteLine("Ingredients:\n");
                for (int i = 0; i < ing.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + ing[i].IngQuantity + " " + ing[i].IngUnitOfMeasure + " " + ing[i].IngName);
                }

                Console.WriteLine("\nSteps:\n");
                for (int i = 0; i < steps.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + steps[i].StepDescription);
                }
                Console.WriteLine("****************************\n\n");
            }
            else
            {
                Console.WriteLine("No recipe to display. Please enter a new recipe first.");
            }
        }

        public void MainMenu()
        {
            Ingredients[] ing = new Ingredients[0];
            Steps[] stp = new Steps[0];
            int choice;
            while (true)
            {
                try
                {
                    Console.WriteLine("\n****************************");
                    Console.WriteLine("            MENU            ");
                    Console.WriteLine("****************************");
                    Console.WriteLine("1) Enter a new recipe");
                    Console.WriteLine("2) Scale recipe");
                    Console.WriteLine("3) Reset quantities");
                    Console.WriteLine("4) Clear all data");
                    Console.WriteLine("5) Exit");
                    Console.WriteLine("****************************");

                    Console.Write("Enter your choice: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n\nPlease enter a number thats on the menu!\n");
                    continue;
                }
                if (choice == 1)
                {
                    ing = this.ing.GetIngredients();
                    stp = this.stp.GetSteps();
                }
                else if (choice == 2)
                {
                    Console.Write("Please enter the number you would like to scale the recipe by (Put in 0.5 for half, 2 for double or 3 for triple): ");
                    double factor = Convert.ToDouble(Console.ReadLine());
                    ScaleRecipe(ing, factor);
                }
                else if (choice == 3)
                {
                    ResetNewQuantities(ing);
                }
                else if (choice == 4)
                {
                    ClearAllData();
                    ing = new Ingredients[0];
                    stp = new Steps[0];
                }
                else if (choice == 5)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("\n\nPlease enter a number thats on the menu!\n");
                    continue;
                }

                DisplayRecipe(ing, stp);
            }
        }
    }
}