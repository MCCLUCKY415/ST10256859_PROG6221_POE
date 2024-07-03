// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References:
// - https://youtube.com/playlist?list=PLih2KERbY1HHOOJ2C6FOrVXIwg4AZ-hk1&si=FOktN0cM5CWF7X4z
// - GitHub Copilot for assisting with the structure of the code and helping me find and fix errors.
// - ChatGPT for assisting me with finding and fixing errors in the code.

using ST10256859_PROG6221_POE_PART1.Classes;
using ST10256859_PROG6221_POE_WPF.DisplayAlterRecipeWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ST10256859_PROG6221_POE_WPF.Windows
{
    /// <summary>
    /// Interaction logic for DisplayAlterWindow.xaml
    /// </summary>
    public partial class DisplayAlterWindow : Window
    {
        // Reference to the MainWindow instance
        private MainWindow mainWin;

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Constructor for DisplayAlterWindow
        public DisplayAlterWindow(MainWindow mw)
        {
            InitializeComponent(); // Initialize the components defined in the XAML

            this.mainWin = mw; // Store the reference to the MainWindow instance
            this.mainWin.Hide(); // Hide the MainWindow
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Event handler for the "Display All Recipes" button click
        private void DisplayAllRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            var displayAllRecipesWindow = new DisplayAllRecipesWindow(this); // Create an instance of the DisplayAllRecipesWindow
            displayAllRecipesWindow.Show(); // Show the DisplayAllRecipesWindow
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Event handler for the "Search For Recipe" button click
        private void SearchForRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            var searchForRecipeWindow = new SearchForRecipeWindow(this); // Create an instance of the SearchForRecipeWindow
            searchForRecipeWindow.Show(); // Show the SearchForRecipeWindow
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Event handler for the "Scale Recipe" button click
        private void ScaleRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            var scaleRecipeWindow = new ScaleRecipeWindow(this); // Create an instance of the ScaleRecipeWindow
            scaleRecipeWindow.Show(); // Show the ScaleRecipeWindow
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Event handler for the "Clear All Recipes" button click
        private void ClearAllRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            List<Recipe> recipes = new List<Recipe>(); // Initialize a new list to store recipes

            // Show a MessageBox to confirm clearing recipes
            MessageBoxResult result = MessageBox.Show("Are you sure you want to clear all recipes?", "Confirm Clear", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Clear the list of recipes in the MainWindow
                mainWin.recipes = recipes;
                // Show a message indicating that all recipes have been cleared
                MessageBox.Show("All recipes have been cleared.", "Recipes Cleared", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Override the OnClosed method to handle window closing events
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.mainWin.Show(); // Show the MainWindow when this window is closed
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Method to get the list of recipes from the MainWindow
        public List<Recipe> GetRecipes()
        {
            return mainWin.recipes;
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Method to search for recipes based on criteria
        public List<Recipe> SearchForRecipes(string ingredientName, string foodGroup, string maxCalories)
        {
            List<Recipe> recipes = mainWin.recipes; // Get the list of recipes from MainWindow
            List<Recipe> searchResults = new List<Recipe>(); // Initialize a list to store search results

            // Parse the maxCalories input if provided
            int maxCaloriesValue = 0;
            bool maxCaloriesProvided = int.TryParse(maxCalories, out maxCaloriesValue);

            // Iterate through each recipe
            foreach (Recipe recipe in recipes)
            {
                bool matchesIngredient = false;
                bool matchesFoodGroup = false;
                bool matchesMaxCalories = !maxCaloriesProvided || recipe.CalculateTotalCalories() <= maxCaloriesValue;

                // Check each ingredient in the recipe
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    if (!string.IsNullOrEmpty(ingredientName) && ingredient.IngName.Equals(ingredientName, StringComparison.OrdinalIgnoreCase))
                    {
                        matchesIngredient = true;
                    }

                    if (!string.IsNullOrEmpty(foodGroup) && ingredient.FoodGroup.Equals(foodGroup, StringComparison.OrdinalIgnoreCase))
                    {
                        matchesFoodGroup = true;
                    }
                }

                // Check if the recipe matches any of the provided criteria
                if ((matchesIngredient || string.IsNullOrEmpty(ingredientName)) &&
                    (matchesFoodGroup || string.IsNullOrEmpty(foodGroup)) &&
                    matchesMaxCalories)
                {
                    searchResults.Add(recipe); // Add the recipe to search results
                }
            }

            return searchResults; // Return the search results
        }
        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
    }
}

//-----------------------------------------------------------------------------END OF FILE-----------------------------------------------------------------------------