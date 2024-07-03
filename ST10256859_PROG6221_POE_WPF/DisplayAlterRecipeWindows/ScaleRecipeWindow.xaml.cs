// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References:
// - https://youtube.com/playlist?list=PLih2KERbY1HHOOJ2C6FOrVXIwg4AZ-hk1&si=FOktN0cM5CWF7X4z
// - GitHub Copilot for assisting with the structure of the code and helping me find and fix errors.
// - ChatGPT for assisting me with finding and fixing errors in the code.

using ST10256859_PROG6221_POE_PART1.Classes;
using ST10256859_PROG6221_POE_WPF.Windows;
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

namespace ST10256859_PROG6221_POE_WPF.DisplayAlterRecipeWindows
{
    /// <summary>
    /// Interaction logic for ScaleRecipeWindow.xaml
    /// </summary>
    public partial class ScaleRecipeWindow : Window
    {
        private DisplayAlterWindow displayAlterWin; // Reference to the DisplayAlterWindow instance

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Constructor for ScaleRecipeWindow
        public ScaleRecipeWindow(DisplayAlterWindow daw)
        {
            InitializeComponent(); // Initialize the components defined in the XAML

            this.displayAlterWin = daw; // Store the reference to the DisplayAlterWindow instance
            this.displayAlterWin.Hide(); // Hide the DisplayAlterWindow while this window is open
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Event handler for the "Half Scale" button click
        private void halfScaleButton_Click(object sender, RoutedEventArgs e)
        {
            ScaleRecipe(0.5, "scaled to half"); // Scale the recipe to half its original size
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Event handler for the "Double Scale" button click
        private void doubleScaleButton_Click(object sender, RoutedEventArgs e)
        {
            ScaleRecipe(2, "doubled"); // Scale the recipe to double its original size
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Event handler for the "Triple Scale" button click
        private void tripleScaleButton_Click(object sender, RoutedEventArgs e)
        {
            ScaleRecipe(3, "tripled"); // Scale the recipe to triple its original size
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Method to scale the recipe
        private void ScaleRecipe(double scaleFactor, string scaleDescription)
        {
            // Get the list of recipes from DisplayAlterWindow
            List<Recipe> recipes = displayAlterWin.GetRecipes();
            // Get the recipe name from the input textbox
            string recipeName = scaleRecipeTextBox.Text.Trim();
            if (string.IsNullOrEmpty(recipeName))
            {
                MessageBox.Show("Please enter a recipe name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Find the recipe to scale
            Recipe recipeToScale = recipes.FirstOrDefault(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipeToScale == null)
            {
                MessageBox.Show("Recipe not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Scale the ingredients
            foreach (var ingredient in recipeToScale.Ingredients)
            {
                ingredient.IngQuantity *= scaleFactor;
                ingredient.Calories *= scaleFactor;
            }

            MessageBox.Show($"The ingredients of the recipe '{recipeName}' have been {scaleDescription}.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Clear existing children in the recipe details panel
            recipeDetailsPanel.Children.Clear();

            // Create a TextBlock to display the scaled recipe details
            TextBlock recipeDetailsTextBox = new TextBlock
            {
                Text = recipeToScale.GetRecipeDetails(), // Get the scaled recipe details
                FontSize = 16,
                Foreground = Brushes.White,
                Background = Brushes.Transparent,
                Margin = new Thickness(0, 10, 0, 10),
                TextWrapping = TextWrapping.Wrap,
            };

            // Add the TextBlock to the recipeDetailsPanel
            recipeDetailsPanel.Children.Add(recipeDetailsTextBox);
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Event handler for the "Reset Quantities" button click
        private void resetQuantitiesButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the list of recipes from DisplayAlterWindow
            List<Recipe> recipes = displayAlterWin.GetRecipes();
            // Get the recipe name from the input textbox
            string recipeName = scaleRecipeTextBox.Text.Trim();
            if (string.IsNullOrEmpty(recipeName))
            {
                MessageBox.Show("Please enter a recipe name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Find the recipe to reset
            Recipe recipeToScale = recipes.FirstOrDefault(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipeToScale == null)
            {
                MessageBox.Show("Recipe not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Reset the ingredients to their original quantities
            foreach (var ingredient in recipeToScale.Ingredients)
            {
                ingredient.IngQuantity = ingredient.OriginalIngQuantity;
                ingredient.Calories = ingredient.OriginalCalories;
            }

            MessageBox.Show($"The ingredients of the recipe '{recipeName}' have been reset to their original quantities.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Clear existing children in the recipe details panel
            recipeDetailsPanel.Children.Clear();

            // Create a TextBlock to display the reset recipe details
            TextBlock recipeDetailsTextBox = new TextBlock
            {
                Text = recipeToScale.GetRecipeDetails(), // Get the reset recipe details
                FontSize = 16,
                Foreground = Brushes.White,
                Background = Brushes.Transparent,
                Margin = new Thickness(0, 10, 0, 10),
                TextWrapping = TextWrapping.Wrap,
            };

            // Add the TextBlock to the recipeDetailsPanel
            recipeDetailsPanel.Children.Add(recipeDetailsTextBox);
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Override the OnClosed method to handle window closing events
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.displayAlterWin.Show(); // Show the DisplayAlterWindow when this window is closed
        }
        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
    }
}

//-----------------------------------------------------------------------------END OF FILE-----------------------------------------------------------------------------