using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10256859_PROG6221_POE_PART1.Classes
{
    public class Recipe
    {
        public string RecipeName { get; set; }  // The name of the recipe.
        public List<Ingredients> Ingredients { get; set; }  // List of ingredients in the recipe.
        public List<Steps> Steps { get; set; }  // List of steps in the recipe.
        public double TotalCalories { get; set; }  // Total calories of the recipe.

        public Recipe(string recipeName, List<Ingredients> ingredients, List<Steps> steps)
        {
            RecipeName = recipeName;
            Ingredients = ingredients;
            Steps = steps;
            CalculateTotalCalories();
        }

        // Method to calculate the total calories of the recipe.
        private void CalculateTotalCalories()
        {
            TotalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                TotalCalories += ingredient.Calories;
            }
        }
    }
}
