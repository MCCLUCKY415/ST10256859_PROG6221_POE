using System;

namespace ST10256859_PROG6221_POE_PART1.Classes
{
    public class RecipeProcesses
    {
        private Ingredients ing = new Ingredients();
        private Steps stp = new Steps();

        public void ScaleRecipe(Ingredients[] ing, double factor)
        {
            foreach (var ingredient in ing)
            {
                ingredient.IngQuantity = ingredient.OriginalIngQuantity * factor;
            }
        }

        public void ResetNewQuantities(Ingredients[] ing)
        {
            foreach (var ingredient in ing)
            {
                ingredient.IngQuantity = ingredient.OriginalIngQuantity;
            }
        }

        public void ClearAllData()
        {
            ing = new Ingredients();
            stp = new Steps();
        }

        public void DisplayRecipe(Ingredients[] ing, Steps[] steps)
        {
            Console.WriteLine("\n            RECIPE            ");
            Console.WriteLine("*******************************");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ing)
            {
                Console.WriteLine(ingredient.IngQuantity + " " + ingredient.IngUnitOfMeasure + " " + ingredient.IngName);
            }

            Console.WriteLine("\nSteps:");
            foreach (var step in steps)
            {
                Console.WriteLine(step.StepDescription);
            }
        }

        public void MainMenu(Ingredients[] ing, Steps[] stp)
        {
            while (true)
            {
                DisplayRecipe(ing, stp);

                Console.WriteLine("\n            MENU            ");
                Console.WriteLine("*****************************");
                Console.WriteLine("1) Enter a new recipe");
                Console.WriteLine("2) Scale recipe");
                Console.WriteLine("3) Reset quantities");
                Console.WriteLine("4) Clear all data");
                Console.WriteLine("5) Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    // Code to handle entering a new recipe
                    break;
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
                }
                else if (choice == 5)
                {
                    return;
                }
            }
        }
    }
}