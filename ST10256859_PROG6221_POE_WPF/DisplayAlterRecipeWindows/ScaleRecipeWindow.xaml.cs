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
        private DisplayAlterWindow displayAlterWin;

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        public ScaleRecipeWindow(DisplayAlterWindow daw)
        {
            InitializeComponent();

            this.displayAlterWin = daw;
            this.displayAlterWin.Hide();
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        private void halfScaleButton_Click(object sender, RoutedEventArgs e)
        {
            List<Recipe> recipes = displayAlterWin.GetRecipes();
            string recipeName = scaleRecipeTextBox.Text.Trim();
            if (string.IsNullOrEmpty(recipeName))
            {
                MessageBox.Show("Please enter a recipe name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Recipe recipeToScale = recipes.FirstOrDefault(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipeToScale == null)
            {
                MessageBox.Show("Recipe not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Scale the ingredients by half
            foreach (var ingredient in recipeToScale.Ingredients)
            {
                ingredient.IngQuantity /= 2;
            }

            MessageBox.Show($"The ingredients of the recipe '{recipeName}' have been scaled to half.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Clear existing children
            recipeDetailsPanel.Children.Clear();

            // Create a TextBox to display the scaled recipe details
            TextBox recipeDetailsTextBox = new TextBox
            {
                Text = recipeToScale.GetRecipeDetails(),
                FontSize = 16,
                Foreground = Brushes.White,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                Margin = new Thickness(0, 10, 0, 10),
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                TextWrapping = TextWrapping.Wrap,
                IsReadOnly = true
            };

            // Add the TextBox to the recipeDetailsPanel
            recipeDetailsPanel.Children.Add(recipeDetailsTextBox);
        }



        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        private void doubleScaleButton_Click(object sender, RoutedEventArgs e)
        {
            List<Recipe> recipes = displayAlterWin.GetRecipes();
            string recipeName = scaleRecipeTextBox.Text.Trim();
            if (string.IsNullOrEmpty(recipeName))
            {
                MessageBox.Show("Please enter a recipe name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Recipe recipeToScale = recipes.FirstOrDefault(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipeToScale == null)
            {
                MessageBox.Show("Recipe not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Scale the ingredients by half
            foreach (var ingredient in recipeToScale.Ingredients)
            {
                ingredient.IngQuantity *= 2;
            }

            MessageBox.Show($"The ingredients of the recipe '{recipeName}' have been scaled to half.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Clear existing children
            recipeDetailsPanel.Children.Clear();

            // Create a TextBox to display the scaled recipe details
            TextBox recipeDetailsTextBox = new TextBox
            {
                Text = recipeToScale.GetRecipeDetails(),
                FontSize = 16,
                Foreground = Brushes.White,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                Margin = new Thickness(0, 10, 0, 10),
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                TextWrapping = TextWrapping.Wrap,
                IsReadOnly = true
            };

            // Add the TextBox to the recipeDetailsPanel
            recipeDetailsPanel.Children.Add(recipeDetailsTextBox);
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        private void tripleScaleButton_Click(object sender, RoutedEventArgs e)
        {
            List<Recipe> recipes = displayAlterWin.GetRecipes();
            string recipeName = scaleRecipeTextBox.Text.Trim();
            if (string.IsNullOrEmpty(recipeName))
            {
                MessageBox.Show("Please enter a recipe name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Recipe recipeToScale = recipes.FirstOrDefault(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipeToScale == null)
            {
                MessageBox.Show("Recipe not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Scale the ingredients by half
            foreach (var ingredient in recipeToScale.Ingredients)
            {
                ingredient.IngQuantity *= 3;
            }

            MessageBox.Show($"The ingredients of the recipe '{recipeName}' have been scaled to half.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Clear existing children
            recipeDetailsPanel.Children.Clear();

            // Create a TextBox to display the scaled recipe details
            TextBox recipeDetailsTextBox = new TextBox
            {
                Text = recipeToScale.GetRecipeDetails(),
                FontSize = 16,
                Foreground = Brushes.White,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                Margin = new Thickness(0, 10, 0, 10),
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                TextWrapping = TextWrapping.Wrap,
                IsReadOnly = true
            };

            // Add the TextBox to the recipeDetailsPanel
            recipeDetailsPanel.Children.Add(recipeDetailsTextBox);
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        private void resetQuantitiesButton_Click(object sender, RoutedEventArgs e)
        {
            List<Recipe> recipes = displayAlterWin.GetRecipes();
            string recipeName = scaleRecipeTextBox.Text.Trim();
            if (string.IsNullOrEmpty(recipeName))
            {
                MessageBox.Show("Please enter a recipe name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Recipe recipeToScale = recipes.FirstOrDefault(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipeToScale == null)
            {
                MessageBox.Show("Recipe not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Reset the ingredients to their original quantities
            foreach (var ingredient in recipeToScale.Ingredients)
            {
                ingredient.IngQuantity = ingredient.OriginalQuantity;
            }

            MessageBox.Show($"The ingredients of the recipe '{recipeName}' have been reset to their original quantities.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Clear existing children
            recipeDetailsPanel.Children.Clear();

            // Create a TextBox to display the reset recipe details
            TextBox recipeDetailsTextBox = new TextBox
            {
                Text = recipeToScale.GetRecipeDetails(),
                FontSize = 16,
                Foreground = Brushes.White,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                Margin = new Thickness(0, 10, 0, 10),
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                TextWrapping = TextWrapping.Wrap,
                IsReadOnly = true
            };

            // Add the TextBox to the recipeDetailsPanel
            recipeDetailsPanel.Children.Add(recipeDetailsTextBox);
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.displayAlterWin.Show();
        }
        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
    }
}
