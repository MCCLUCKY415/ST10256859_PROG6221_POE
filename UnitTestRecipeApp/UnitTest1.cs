// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References:
// - YouTube: https://youtu.be/HYrXogLj7vg?si=XJ9N38y0vvFEt2Yz
// - GitHub Copilot for assisting with the structure of the code and helping me find and fix errors.
// - Microsoft Copilot for assisting me with finding and fixing errors in the code.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST10256859_PROG6221_POE_PART1.Classes;
using System;
using System.Collections.Generic;

namespace UnitTestRecipeApp
{
    [TestClass]
    public class UnitTest1
    {
        // Test method to check the total calorie calculation for a recipe.
        [TestMethod]
        public void TestTotalCalorieCalc()
        {
            // Arrange

            // Create ingredients for the recipe
            var ingredients = new List<Ingredients>
            {
                new Ingredients
                {
                    IngName = "Ingredient 1",
                    IngQuantity = 100,
                    IngUnitOfMeasure = "grams",
                    OriginalIngQuantity = 100,
                    OriginalIngUnitOfMeasure = "grams",
                    Calories = 50,
                    OriginalCalories = 50,
                    FoodGroup = "Vegetables"
                },
                new Ingredients
                {
                    IngName = "Ingredient 2",
                    IngQuantity = 2,
                    IngUnitOfMeasure = "tablespoons",
                    OriginalIngQuantity = 2,
                    OriginalIngUnitOfMeasure = "tablespoons",
                    Calories = 30,
                    OriginalCalories = 30,
                    FoodGroup = "Protein"
                }
            };

            // Create a recipe with the ingredients
            var recipe = new Recipe("Test Recipe", ingredients, new List<Steps>());

            // Expected total calories calculation
            double expectedTotalCalories = 50 + 30;

            // Act

            // Calculate the actual total calories of the recipe
            double actualTotalCalories = recipe.CalculateTotalCalories();

            // Assert

            // Compare expected and actual total calories
            Assert.AreEqual(expectedTotalCalories, actualTotalCalories);
        }
    }
}

//-----------------------------------------------------------------------------END OF FILE-----------------------------------------------------------------------------