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
    // This class is responsible for handling the ingredients of a recipe.
    public class Ingredient
    {
        // Properties for ingredient details
        public string IngName { get; set; }  // The name of the ingredient.
        public string IngUnitOfMeasure { get; set; }  // The unit of measurement for the ingredient (e.g., tablespoons, teaspoons, litres, etc.).
        public double IngQuantity { get; set; }  // The quantity of the ingredient.
        public double OriginalIngQuantity { get; set; }  // The original quantity of the ingredient. This is used for resetting quantities after scaling.
        public string OriginalIngUnitOfMeasure { get; set; }  // The original unit of measurement for the ingredient. This is used for resetting units of measurement after scaling.
        public double Calories { get; set; }  // The number of calories.
        public double OriginalCalories { get; set; }  // The original number of calories. This is used for resetting calories after scaling.
        public string FoodGroup { get; set; }  // The food group of the ingredient.

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Constructor to initialize all properties
        public Ingredient(string ingName, string ingUnitOfMeasure, double ingQuantity, double calories, string foodGroup)
        {
            IngName = ingName;
            IngUnitOfMeasure = ingUnitOfMeasure;
            IngQuantity = ingQuantity;
            OriginalIngQuantity = ingQuantity;
            OriginalIngUnitOfMeasure = ingUnitOfMeasure;
            Calories = calories;
            OriginalCalories = calories;
            FoodGroup = foodGroup;
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Method to reset the ingredient to its original values
        public void ResetToOriginal()
        {
            IngQuantity = OriginalIngQuantity;
            IngUnitOfMeasure = OriginalIngUnitOfMeasure;
            Calories = OriginalCalories;
        }
        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
    }
}

//-----------------------------------------------------------------------------END OF FILE-----------------------------------------------------------------------------