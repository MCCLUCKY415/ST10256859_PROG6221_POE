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

                    // Convert teaspoons to tablespoons if quantity is 3 or more
                    if (ingredient.IngUnitOfMeasure.ToLower() == "teaspoons" && ingredient.IngQuantity >= 3)
                    {
                        ingredient.IngQuantity /= 3;
                        ingredient.IngUnitOfMeasure = "tablespoons";
                    }

                    // Convert tablespoons to cups if quantity is 16 or more
                    else if (ingredient.IngUnitOfMeasure.ToLower() == "tablespoons" && ingredient.IngQuantity >= 16)
                    {
                        ingredient.IngQuantity /= 16;
                        ingredient.IngUnitOfMeasure = "cups";
                    }

                    //covert tablespoons to teaspoons if quantity is less than 1
                    else if (ingredient.IngUnitOfMeasure.ToLower() == "tablespoons" && ingredient.IngQuantity < 1)
                    {
                        ingredient.IngQuantity *= 3;
                        ingredient.IngUnitOfMeasure = "teaspoons";
                    }

                    //convert cups to tablespoons if quantity is less than 1
                    else if (ingredient.IngUnitOfMeasure.ToLower() == "cups" && ingredient.IngQuantity < 1)
                    {
                        ingredient.IngQuantity *= 16;
                        ingredient.IngUnitOfMeasure = "tablespoons";
                    }
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
                    ingredient.IngUnitOfMeasure = ingredient.OriginalIngUnitOfMeasure;
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