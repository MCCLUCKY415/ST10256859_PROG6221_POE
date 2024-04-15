using System;

namespace ST10256859_PROG6221_POE_PART1.Classes
{
    public class AlteringRecipeProcesses
    {
        private Ingredients ing = new Ingredients();
        private Steps stp = new Steps();

        public void ScaleRecipe(Ingredients[] ing, double factor)
        {
            if (factor != 0.5 && factor != 2 && factor != 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nInvalid scale factor. Please enter '0.5' for half, '2' for double, or '3' for triple.\n\n");
                Console.ResetColor();
                return;
            }

            if (ing != null && ing.Length > 0)
            {
                foreach (var ingredient in ing)
                {
                    ingredient.IngQuantity = ingredient.OriginalIngQuantity * factor;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nNo ingredients to scale. Please enter a new recipe first!\n\n");
                Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nNo ingredients to reset. Please enter a new recipe first!\n\n");
                Console.ResetColor();
            }
        }

        public void ClearAllData()
        {
            ing = new Ingredients();
            stp = new Steps();
        }
    }
}