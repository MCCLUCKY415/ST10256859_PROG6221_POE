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
using System.Text;

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
            return $"-----------------------------------\n" +
                   $"Recipe Name: {RecipeName}\n" +
                   $"-----------------------------------\n" +
                   $"Total Number of Ingredients: {Ingredients.Count}\n" +
                   $"Total Number of Steps: {Steps.Count}\n" +
                   $"Total Number of Calories: {CalculateTotalCalories()}\n" +
                   $"-----------------------------------\n";
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        //Method to generate 20 random recipes
        public static List<Recipe> GenerateRandomRecipes()
        {
            var random = new Random();
            var recipes = new List<Recipe>();
            var foodGroups = new[] { "Vegetables", "Fruits", "Grains", "Proteins", "Dairy" };
            var unitOfMeasures = new[] { "grams", "cups", "tablespoons", "teaspoons", "pieces" };
            var ingredientNames = new[] { "Sugar", "Salt", "Flour", "Butter", "Milk", "Eggs", "Tomato", "Lettuce", "Chicken", "Beef" };

            for (int i = 0; i < 20; i++)
            {
                var recipeName = $"Recipe {i + 1}";
                var ingredients = new List<Ingredient>();
                var steps = new List<Step>();

                for (int j = 0; j < random.Next(3, 10); j++)
                {
                    var ingName = ingredientNames[random.Next(ingredientNames.Length)];
                    var ingUnit = unitOfMeasures[random.Next(unitOfMeasures.Length)];
                    var ingQuantity = random.Next(1, 500);
                    var calories = random.Next(50, 500);
                    var foodGroup = foodGroups[random.Next(foodGroups.Length)];

                    ingredients.Add(new Ingredient(ingName, ingUnit, ingQuantity, calories, foodGroup));
                }

                for (int k = 0; k < random.Next(1, 5); k++)
                {
                    steps.Add(new Step($"Step description {k + 1}"));
                }

                recipes.Add(new Recipe(recipeName, ingredients, steps));
            }

            return recipes;
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Method to get the details of the recipe.
        public string GetRecipeDetails()
        {
            var details = new StringBuilder();

            // Recipe header
            details.AppendLine("-----------------------------------------------------");
            details.AppendLine($"Recipe Name: {RecipeName}");
            details.AppendLine("-----------------------------------------------------");

            // Ingredients header
            details.AppendLine("Ingredients:");
            details.AppendLine("-------------");
            foreach (var ingredient in Ingredients)
            {
                details.AppendLine($"- {ingredient.IngQuantity} {ingredient.IngUnitOfMeasure} of {ingredient.IngName} ({ingredient.Calories} calories)");
            }
            details.AppendLine("-----------------------------------------------------");

            // Steps header
            details.AppendLine("Steps:");
            details.AppendLine("-------");
            int stepNumber = 1;
            foreach (var step in Steps)
            {
                details.AppendLine($"Step {stepNumber}: {step.StepDescription}");
                stepNumber++;
            }

            // Recipe statistics
            details.AppendLine("-----------------------------------------------------");
            details.AppendLine($"Total Number of Ingredients: {Ingredients.Count}");
            details.AppendLine($"Total Number of Steps: {Steps.Count}");

            // Calculate total calories
            double totalCalories = CalculateTotalCalories();
            details.AppendLine($"Total Number of Calories: {totalCalories}");
            details.AppendLine("-----------------------------------------------------");

            // Add calorie message
            if (totalCalories < 150)
            {
                details.AppendLine("This recipe is low in calories, making it a great\nchoice for a light snack.");
            }
            else if (totalCalories >= 150 && totalCalories <= 300)
            {
                details.AppendLine("This recipe contains a moderate amount of\ncalories, perfect for a balanced meal.");
            }
            else
            {
                details.AppendLine("This recipe is high in calories and should be\nenjoyed in moderation.");
            }

            details.AppendLine("-----------------------------------------------------\n\n\n\n");

            return details.ToString();
        }
        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
    }
}

//-----------------------------------------------------------------------------END OF FILE-----------------------------------------------------------------------------