using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10256859_PROG6221_POE_PART1.Classes
{
    public class RecipeManagement
    {
        private List<Recipe> recipes = new List<Recipe>();

        public void AddRecipe(string recipeName)
        {
           Recipe newRecipe = new Recipe(recipeName);
           recipes.Add(newRecipe);
        }

        public void AlphabeticalDisay()
        {
            var sortedRecipes = recipes.OrderBy(rec => rec.Name);
            foreach (var recipe in sortedRecipes)
            {
                Console.WriteLine(recipe.Name);
            }
        }
    }
}
