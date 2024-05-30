// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References: List of references:
//             https://stackoverflow.com/questions/71967411/how-can-i-try-catch-an-exception-for-a-negative-number-in-c
//             https://youtu.be/QqWfw_CFR6Q?si=OWgC9KPJosQBqu5V
//             https://youtu.be/IHMmPVEOT64?si=FN64GWD1dU8C1i4E
//             https://youtu.be/aNTDJ9bnRU4?si=2f7p21l9Uz2IPAam
//             https://youtu.be/aNTDJ9bnRU4?si=2f7p21l9Uz2IPAam
//             GitHub Copilot for assisting with the structure of the code.
//             Microsoft Copilot for assisting me with finding and fixing errors in the code.

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
        public string FoodGroup { get; set; }  // The food group of the recipe.


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
