// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References: List of references:
//             https://stackoverflow.com/questions/71967411/how-can-i-try-catch-an-exception-for-a-negative-number-in-c
//             https://youtu.be/QqWfw_CFR6Q?si=OWgC9KPJosQBqu5V
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
    // This class manages the collection of recipes.
    public class RecipeManagement
    {
        // List to store all recipes.
        private List<Recipe> recipes = new List<Recipe>();

        // Method to add a new recipe to the collection.
        public void AddRecipe(string recipeName)
        {
            // Create a new Recipe object with an empty list of ingredients and steps.
            Recipe newRecipe = new Recipe(recipeName, new List<Ingredients>(), new List<Steps>());

            // Add the new recipe to the collection.
            recipes.Add(newRecipe);
        }

        // Method to display all recipes in alphabetical order by recipe name.
        public void AlphabeticalDisplay()
        {
            // Sort recipes by recipe name in ascending order.
            var sortedRecipes = recipes.OrderBy(rec => rec.RecipeName);

            // Display each recipe name.
            foreach (var recipe in sortedRecipes)
            {
                Console.WriteLine(recipe.RecipeName);
            }
        }
    }
}

//-----------------------------------------------------------------------------END OF FILE-----------------------------------------------------------------------------
