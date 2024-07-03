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
        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        [TestMethod]
        public void CalculateTotalCalories_NoIngredients_ReturnsZero()
        {
            // Arrange
            var recipe = new Recipe("Test Recipe", new List<Ingredient>(), new List<Step>());

            // Act
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(0, totalCalories);
        }

        [TestMethod]
        public void CalculateTotalCalories_SingleIngredient_ReturnsCorrectCalories()
        {
            // Arrange
            var ingredients = new List<Ingredient>
            {
                new Ingredient("Ingredient 1", "", 0, 100, "")
            };
            var recipe = new Recipe("Test Recipe", ingredients, new List<Step>());

            // Act
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(100, totalCalories);
        }

        [TestMethod]
        public void CalculateTotalCalories_MultipleIngredients_ReturnsSumOfCalories()
        {
            // Arrange
            var ingredients = new List<Ingredient>
            {
                new Ingredient("Ingredient 1", "", 0, 50, ""),
                new Ingredient("Ingredient 2", "", 0, 75, ""),
                new Ingredient("Ingredient 3", "", 0, 30, "")
            };
            var recipe = new Recipe("Test Recipe", ingredients, new List<Step>());

            // Act
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(50 + 75 + 30, totalCalories);
        }
        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
    }
}

//-----------------------------------------------------------------------------END OF FILE-----------------------------------------------------------------------------