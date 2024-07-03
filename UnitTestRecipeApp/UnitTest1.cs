// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References:
// - YouTube: https://youtu.be/HYrXogLj7vg?si=XJ9N38y0vvFEt2Yz
// - GitHub Copilot for assisting with the structure of the code and helping me find and fix errors.
// - ChatGPT for assisting me with finding and fixing errors in the code.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST10256859_PROG6221_POE_PART1.Classes;
using System;
using System.Collections.Generic;

namespace UnitTestRecipeApp
{
    [TestClass]
    public class UnitTest1
    {
        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Test method to verify CalculateTotalCalories returns 0 when there are no ingredients.
        [TestMethod]
        public void CalculateTotalCalories_NoIngredients_ReturnsZero()
        {
            // Arrange: Create a recipe with no ingredients.
            var recipe = new Recipe("Test Recipe", new List<Ingredient>(), new List<Step>());

            // Act: Calculate the total calories of the recipe.
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert: Verify that the total calories is 0.
            Assert.AreEqual(0, totalCalories);
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Test method to verify CalculateTotalCalories returns the correct value for a single ingredient.
        [TestMethod]
        public void CalculateTotalCalories_SingleIngredient_ReturnsCorrectCalories()
        {
            // Arrange: Create a list with a single ingredient containing 100 calories.
            var ingredients = new List<Ingredient>
            {
                new Ingredient("Ingredient 1", "", 0, 100, "")
            };
            // Create a recipe with the single ingredient.
            var recipe = new Recipe("Test Recipe", ingredients, new List<Step>());

            // Act: Calculate the total calories of the recipe.
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert: Verify that the total calories is 100.
            Assert.AreEqual(100, totalCalories);
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Test method to verify CalculateTotalCalories returns the sum of calories for multiple ingredients.
        [TestMethod]
        public void CalculateTotalCalories_MultipleIngredients_ReturnsSumOfCalories()
        {
            // Arrange: Create a list with multiple ingredients.
            var ingredients = new List<Ingredient>
            {
                new Ingredient("Ingredient 1", "", 0, 50, ""),
                new Ingredient("Ingredient 2", "", 0, 75, ""),
                new Ingredient("Ingredient 3", "", 0, 30, "")
            };
            // Create a recipe with the multiple ingredients.
            var recipe = new Recipe("Test Recipe", ingredients, new List<Step>());

            // Act: Calculate the total calories of the recipe.
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert: Verify that the total calories is the sum of individual ingredient calories (50 + 75 + 30).
            Assert.AreEqual(50 + 75 + 30, totalCalories);
        }
        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
    }
}

//-----------------------------------------------------------------------------END OF FILE-----------------------------------------------------------------------------