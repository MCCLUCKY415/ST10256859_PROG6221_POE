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
        private MainWindow mainWin;

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        public DisplayAlterWindow(MainWindow mw)
        {
            InitializeComponent();

            this.mainWin = mw;
            this.mainWin.Hide();
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        private void DisplayAllRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            var displayAllRecipesWindow = new DisplayAllRecipesWindow(this);
            displayAllRecipesWindow.Show();
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        private void SearchForRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            var searchForRecipeWindow = new SearchForRecipeWindow(this);
            searchForRecipeWindow.Show();
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        private void ScaleRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            var scaleRecipeWindow = new ScaleRecipeWindow(this);
            scaleRecipeWindow.Show();

        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        private void ClearAllRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            // Show a MessageBox to confirm clearing recipes
            MessageBoxResult result = MessageBox.Show("Are you sure you want to clear all recipes?", "Confirm Clear", MessageBoxButton.YesNo, MessageBoxImage.Question);

            //if (result == MessageBoxResult.Yes)
            //{
            //    // Clear the list of recipes
            //    recipes.Clear();

            //    // Clear the UI panel where recipes are displayed
            //    recipeDetailsPanel.Children.Clear();

            //    // Optionally, reset any other UI elements or variables related to recipes
            //}
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.mainWin.Show();
        }
        
        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        public List<Recipe> GetRecipes()
        {
            return mainWin.recipes;
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        public List<Recipe> SearchForRecipes(string ingredientName, string foodGroup, string maxCalories)
        {
            List<Recipe> recipes = mainWin.recipes;
            List<Recipe> searchResults = new List<Recipe>();

            int maxCaloriesValue = 0;
            bool maxCaloriesProvided = int.TryParse(maxCalories, out maxCaloriesValue);

            foreach (Recipe recipe in recipes)
            {
                bool matchesIngredient = false;
                bool matchesFoodGroup = false;
                bool matchesMaxCalories = !maxCaloriesProvided || recipe.CalculateTotalCalories() <= maxCaloriesValue;

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
                    searchResults.Add(recipe);
                }
            }

            return searchResults;
        }
        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
    }
}
