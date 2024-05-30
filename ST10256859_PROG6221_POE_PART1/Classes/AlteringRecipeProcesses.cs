// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References: List of references:
// - https://stackoverflow.com/questions/71967411/how-can-i-try-catch-an-exception-for-a-negative-number-in-c
// - https://youtu.be/QqWfw_CFR6Q?si=OWgC9KPJosQBqu5V
// - https://youtu.be/IHMmPVEOT64?si=FN64GWD1dU8C1i4E
// - GitHub Copilot for assisting with the structure of the code.
// - Microsoft Copilot for assisting me with finding and fixing errors in the code.

using System;
using System.Collections.Generic;

namespace ST10256859_PROG6221_POE_PART1.Classes
{
    // This class is responsible for altering the ingredients and steps of a recipe.
    public class AlteringRecipeProcesses
    {
        // Declare private instances of the Ingredients and Steps classes.
        private Ingredients ing = new Ingredients();
        private Steps stp = new Steps();

        // This is the ScaleRecipe method, it calculates the new quantity of each ingredient based on the scale factor provided by the user.
        // It only scales the original recipe so it a user scales over and over it'll display the original recipe scaled, not the scaled recipe being further scaled.
        public void ScaleRecipe(List<Ingredients> ingList, double factor)
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
            if (ingList != null && ingList.Count > 0)
            {
                double totalCalories = 0;

                // Loop through the list of Ingredients objects and scale the quantity of each ingredient by the scale factor.
                foreach (var ingredient in ingList)
                {
                    // Reset the unit of measurement to the original one before each scaling operation.
                    ingredient.IngUnitOfMeasure = ingredient.OriginalIngUnitOfMeasure;

                    // Calculate the new quantity of the ingredient based on the original quantity.
                    double newQuantity = ingredient.OriginalIngQuantity * factor;

                    // If the unit of measurement is teaspoons and the quantity is 3 or more, convert the quantity to tablespoons.
                    if (ingredient.IngUnitOfMeasure.ToLower() == "teaspoons" && newQuantity >= 3)
                    {
                        newQuantity /= 3;
                        ingredient.IngUnitOfMeasure = "tablespoons";
                    }
                    // If the unit of measurement is tablespoons and the quantity is 16 or more, convert the quantity to cups.
                    else if (ingredient.IngUnitOfMeasure.ToLower() == "tablespoons" && newQuantity >= 16)
                    {
                        newQuantity /= 16;
                        ingredient.IngUnitOfMeasure = "cups";
                    }
                    // If the unit of measurement is tablespoons and the quantity is less than 1, convert the quantity to teaspoons.
                    else if (ingredient.IngUnitOfMeasure.ToLower() == "tablespoons" && newQuantity < 1)
                    {
                        newQuantity *= 3;
                        ingredient.IngUnitOfMeasure = "teaspoons";
                    }
                    // If the unit of measurement is cups and the quantity is less than 1, convert the quantity to tablespoons.
                    else if (ingredient.IngUnitOfMeasure.ToLower() == "cups" && newQuantity < 1)
                    {
                        newQuantity *= 16;
                        ingredient.IngUnitOfMeasure = "tablespoons";
                    }

                    // Update the ingredient quantity with the new calculated quantity.
                    ingredient.IngQuantity = newQuantity;

                    // Calculate calories for the scaled ingredient
                    double scaledCalories = ingredient.Calories * factor;

                    // Add to total calories
                    totalCalories += scaledCalories;

                    // Update the ingredient calories with the scaled value
                    ingredient.Calories = scaledCalories;
                }

                // Display the total calories of the scaled recipe
                Console.WriteLine($"\nTotal calories for scaled recipe (scale factor {factor}): {totalCalories}");
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
        // It resets all ingredient quantities and units of measurement to their original values.
        public void ResetNewQuantities(List<Ingredients> ingList)
        {
            // Check if there are any ingredients to reset.
            // If not, display an error message and return.
            if (ingList != null && ingList.Count > 0)
            {
                // Loop through the list of Ingredients objects and reset the quantity, unit of measurement, and calories of each ingredient to their original values.
                foreach (var ingredient in ingList)
                {
                    ingredient.IngQuantity = ingredient.OriginalIngQuantity;
                    ingredient.IngUnitOfMeasure = ingredient.OriginalIngUnitOfMeasure;
                    ingredient.Calories = ingredient.OriginalCalories;
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

        // This is the ClearAllData method of the AlteringRecipeProcesses class.
        // It resets the Ingredients and Steps objects to new instances.
        public void ClearAllData()
        {
            // Reset the Ingredients and Steps objects to new instances.
            ing = new Ingredients();
            stp = new Steps();
        }
    }
}

//-----------------------------------------------------------------------------END OF FILE-----------------------------------------------------------------------------