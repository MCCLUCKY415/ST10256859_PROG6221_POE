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
    // This class is responsible for altering the ingredients and steps of a recipe.
    public class AlteringRecipeProcesses
    {
        // Declare private instances of the Ingredients and Steps classes.
        private Ingredients ing = new Ingredients();

        private Steps stp = new Steps();

        // This is the ScaleRecipe method of the AlteringRecipeProcesses class.
        public void ScaleRecipe(Ingredients[] ing, double factor)
        {
            // Check if the scale factor is one of the allowed values (0.5 for half, 2 for double, or 3 for triple).
            // If not, display an error message and return.
            if (factor != 0.5 && factor != 2 && factor != 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nInvalid scale factor. Please enter '0.5' for half, '2' for double, or '3' for triple.\n\n");
                Console.ResetColor();
                return;
            }

            // Check if there are any ingredients to scale.
            // If not, display an error message and return.
            if (ing != null && ing.Length > 0)
            {
                // Loop through the array of Ingredients objects and scale the quantity of each ingredient by the scale factor.
                foreach (var ingredient in ing)
                {
                    // Calculate the new quantity of the ingredient.
                    ingredient.IngQuantity = ingredient.OriginalIngQuantity * factor;

                    // If the unit of measurement is teaspoons and the quantity is 3 or more, convert the quantity to tablespoons.
                    if (ingredient.IngUnitOfMeasure.ToLower() == "teaspoons" && ingredient.IngQuantity >= 3)
                    {
                        ingredient.IngQuantity /= 3;
                        ingredient.IngUnitOfMeasure = "tablespoons";
                    }

                    // If the unit of measurement is tablespoons and the quantity is 16 or more, convert the quantity to cups.
                    else if (ingredient.IngUnitOfMeasure.ToLower() == "tablespoons" && ingredient.IngQuantity >= 16)
                    {
                        ingredient.IngQuantity /= 16;
                        ingredient.IngUnitOfMeasure = "cups";
                    }

                    // If the unit of measurement is tablespoons and the quantity is less than 1, convert the quantity to teaspoons.
                    else if (ingredient.IngUnitOfMeasure.ToLower() == "tablespoons" && ingredient.IngQuantity < 1)
                    {
                        ingredient.IngQuantity *= 3;
                        ingredient.IngUnitOfMeasure = "teaspoons";
                    }

                    // If the unit of measurement is cups and the quantity is less than 1, convert the quantity to tablespoons.
                    else if (ingredient.IngUnitOfMeasure.ToLower() == "cups" && ingredient.IngQuantity < 1)
                    {
                        ingredient.IngQuantity *= 16;
                        ingredient.IngUnitOfMeasure = "tablespoons";
                    }
                }
            }
            // If there are no ingredients to scale, display an error message.
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nNo ingredients to scale. Please enter a new recipe first!\n\n");
                Console.ResetColor();
            }
        }

        // This is the ResetNewQuantities method of the AlteringRecipeProcesses class.
        public void ResetNewQuantities(Ingredients[] ing)
        {
            // Check if there are any ingredients to reset.
            // If not, display an error message and return.
            if (ing != null && ing.Length > 0)
            {
                // Loop through the array of Ingredients objects and reset the quantity and unit of measurement of each ingredient to their original values.
                foreach (var ingredient in ing)
                {
                    ingredient.IngQuantity = ingredient.OriginalIngQuantity;
                    ingredient.IngUnitOfMeasure = ingredient.OriginalIngUnitOfMeasure;
                }
            }
            // If there are no ingredients to reset, display an error message.
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nNo ingredients to reset. Please enter a new recipe first!\n\n");
                Console.ResetColor();
            }
        }

        // This is the ClearAllData method of the AlteringRecipeProcesses class. It clears all data from the Ingredients and Steps objects.
        public void ClearAllData()
        {
            // Reset the Ingredients and Steps objects to new instances.
            ing = new Ingredients();
            stp = new Steps();
        }
    }
}