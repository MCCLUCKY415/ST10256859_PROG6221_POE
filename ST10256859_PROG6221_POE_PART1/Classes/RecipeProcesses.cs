using System;

namespace ST10256859_PROG6221_POE_PART1.Classes
{
    public class RecipeProcesses
    {
        Ingredients ing = new Ingredients();
        Steps stp = new Steps();

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

        public void DisplayRecipe(Ingredients[] ing, Steps[] steps)
        {
            Console.WriteLine("\n            RECIPE            ");
            Console.WriteLine("******************************");
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
    }
}