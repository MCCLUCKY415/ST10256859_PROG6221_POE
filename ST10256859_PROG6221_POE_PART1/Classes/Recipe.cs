// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References:
// - Stack Overflow: https://stackoverflow.com/questions/71967411/how-can-i-try-catch-an-exception-for-a-negative-number-in-c
// - YouTube: https://youtu.be/QqWfw_CFR6Q?si=OWgC9KPJosQBqu5V
// - YouTube: https://youtu.be/IHMmPVEOT64?si=FN64GWD1dU8C1i4E
// - YouTube: https://youtu.be/aNTDJ9bnRU4?si=2f7p21l9Uz2IPAam
// - GitHub Copilot for assisting with the structure of the code.
// - Microsoft Copilot for assisting me with finding and fixing errors in the code.

using System;
using System.Collections.Generic;

namespace ST10256859_PROG6221_POE_PART1.Classes
{
    // This class represents a recipe, containing ingredients, steps, and other details.
    public class Recipe
    {
        public string RecipeName { get; set; }  // The name of the recipe.
        public List<Ingredient> Ingredients { get; set; }  // List of ingredients in the recipe.
        public List<Step> Steps { get; set; }  // List of steps in the recipe.
        public string foodGroup { get; set; }  // The food group of the recipe.

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Constructor to initialize a recipe with its name, ingredients, and steps.
        public Recipe(string recipeName, List<Ingredient> ingredients, List<Step> steps)
        {
            RecipeName = recipeName;
            Ingredients = ingredients;
            Steps = steps;
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Method to calculate the total calories of the recipe.
        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in this.Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Method to get a summary of the recipe.
        public string GetRecipeSummary()
        {
            return $"Recipe: {RecipeName}\n" +
                   $"Total Number of Ingredients: {Ingredients.Count}\n" +
                   $"Total Number of Steps: {Steps.Count}\n" +
                   $"Total Number of Calories: {CalculateTotalCalories()}";
        }
        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
    }
}

//-----------------------------------------------------------------------------END OF FILE-----------------------------------------------------------------------------