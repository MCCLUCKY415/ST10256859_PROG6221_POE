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

                // Sort search results alphabetically by RecipeName
                searchResults = searchResults.OrderBy(r => r.RecipeName).ToList();

                foreach (var recipe in searchResults)
                {
                    // Get recipe details as a single string
                    string recipeDetails = recipe.GetRecipeDetails();
                    // Split the details into lines
                    var lines = recipeDetails.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                    // Create a TextBlock for the entire recipe details
                    TextBlock recipeSummaryBlock = new TextBlock
                    {
                        FontSize = 16,
                        Foreground = Brushes.White,
                        Margin = new Thickness(0, 10, 0, 10),
                        TextWrapping = TextWrapping.Wrap
                    };

                    foreach (var line in lines)
                    {
                        // Create a Run for each line to support individual coloring
                        Run lineRun = new Run(line + "\n");

                        // Check if the line contains the total calories
                        if (line.Contains("Total Number of Calories:"))
                        {
                            // Extract the total calories value
                            var parts = line.Split(':');
                            if (parts.Length == 2 && double.TryParse(parts[1].Trim(), out double totalCalories))
                            {
                                if (totalCalories < 150)
                                {
                                    lineRun.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6cff9b"));
                                }
                                else if (totalCalories >= 150 && totalCalories <= 300)
                                {
                                    lineRun.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ebfa84"));
                                }
                                else
                                {
                                    lineRun.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f24147"));
                                }
                            }
                        }

                        // Add the Run to the TextBlock's Inlines collection
                        recipeSummaryBlock.Inlines.Add(lineRun);
                    }

                    // Add the TextBlock to the panel
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
