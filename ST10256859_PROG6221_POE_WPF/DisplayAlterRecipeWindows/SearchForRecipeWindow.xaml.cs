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
    /// Interaction logic for SearchForRecipeWindow.xaml
    /// </summary>
    public partial class SearchForRecipeWindow : Window
    {
        private DisplayAlterWindow displayAlterWin;

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        public SearchForRecipeWindow(DisplayAlterWindow daw)
        {
            InitializeComponent();

            this.displayAlterWin = daw;
            this.displayAlterWin.Hide();
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        private void searchForRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            string ingredientName = searchIngredientNameTextBox.Text;
            string foodGroup = foodGroupComboBox.Text;
            string maxCalories = searchMaxCaloriesTextBox.Text;
            List<Recipe> searchResults = new List<Recipe>();

            recipeDetailsPanel.Children.Clear();
            if (ingredientName == "" && foodGroup == "" && maxCalories == "")
            {
                MessageBox.Show("Please enter at least one search criteria.");
            }
            else
            {
                searchResults = displayAlterWin.SearchForRecipes(ingredientName, foodGroup, maxCalories);

                if (searchResults.Count == 0)
                {
                    TextBlock noRecipesBlock = new TextBlock
                    {
                        Text = "No recipes found.",
                        FontSize = 16,
                        Foreground = Brushes.White,
                        Margin = new Thickness(0, 10, 0, 10)
                    };
                    recipeDetailsPanel.Children.Add(noRecipesBlock);
                    return;
                }
                foreach (var recipe in searchResults)
                {
                    TextBlock recipeSummaryBlock = new TextBlock
                    {
                        Text = recipe.GetRecipeDetails(),
                        FontSize = 16,
                        Foreground = Brushes.White,
                        Margin = new Thickness(0, 10, 0, 10)
                    };

                    recipeDetailsPanel.Children.Add(recipeSummaryBlock);
                }
            }
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
