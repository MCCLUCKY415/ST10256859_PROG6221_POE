using ST10256859_PROG6221_POE_PART1.Classes;
using ST10256859_PROG6221_POE_WPF.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace ST10256859_PROG6221_POE_WPF.DisplayAlterRecipeWindows
{
    /// <summary>
    /// Interaction logic for DisplayAllRecipesWindow.xaml
    /// </summary>
    public partial class DisplayAllRecipesWindow : Window
    {
        private DisplayAlterWindow displayAlterWin;

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        public DisplayAllRecipesWindow(DisplayAlterWindow daw)
        {
            InitializeComponent();

            this.displayAlterWin = daw;
            this.displayAlterWin.Hide();
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        private void DisplayAllRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            List<Recipe> recipes = displayAlterWin.GetRecipes();
            recipeDetailsPanel.Children.Clear();

            if (recipes.Count == 0)
            {
                TextBlock noRecipesBlock = new TextBlock
                {
                    Text = "No recipes to display.",
                    FontSize = 16,
                    Foreground = Brushes.White,
                    Margin = new Thickness(0, 10, 0, 10)
                };
                recipeDetailsPanel.Children.Add(noRecipesBlock);
                return;
            }

            // Sort recipes alphabetically by RecipeName
            recipes = recipes.OrderBy(r => r.RecipeName).ToList();

            foreach (var recipe in recipes)
            {
                // Get recipe details as a single string
                string recipeDetails = recipe.GetRecipeDetails();
                // Split the details into lines
                var lines = recipeDetails.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                // Create a StackPanel to hold recipe details
                StackPanel recipePanel = new StackPanel
                {
                    Margin = new Thickness(0, 10, 0, 10)
                };

                // Initialize checkbox and step text
                CheckBox currentCheckBox = null;

                foreach (var line in lines)
                {
                    // Check if the line contains "Step X: "
                    if (line.StartsWith("Step "))
                    {
                        // Create a CheckBox for the step
                        currentCheckBox = new CheckBox
                        {
                            Content = line,
                            FontSize = 16,
                            Foreground = Brushes.White,
                            Margin = new Thickness(10, 0, 0, 0)
                        };

                        // Add CheckBox to recipe panel
                        recipePanel.Children.Add(currentCheckBox);
                    }
                    else if (currentCheckBox != null)
                    {
                        // Add step description as TextBlock
                        TextBlock stepTextBlock = new TextBlock
                        {
                            Text = line,
                            FontSize = 16,
                            Foreground = GetLineForeground(line), 
                            Margin = new Thickness(20, 0, 0, 0) 
                        };

                        // Add step description TextBlock to recipe panel
                        recipePanel.Children.Add(stepTextBlock);

                        // Reset currentCheckBox to null after adding step description
                        currentCheckBox = null;
                    }
                    else
                    {
                        // Create a TextBlock for other lines (non-step lines)
                        TextBlock lineTextBlock = new TextBlock
                        {
                            Text = line,
                            FontSize = 16,
                            Foreground = GetLineForeground(line), 
                            Margin = new Thickness(0, 0, 0, 5) 
                        };

                        // Add non-step TextBlock to recipe panel
                        recipePanel.Children.Add(lineTextBlock);
                    }
                }

                // Add the recipe panel to the main panel
                recipeDetailsPanel.Children.Add(recipePanel);
            }

            // Method to determine foreground color based on line content
            SolidColorBrush GetLineForeground(string line)
            {
                SolidColorBrush brush = Brushes.White; // Default color

                // Check if the line contains the total calories
                if (line.Contains("Total Number of Calories:"))
                {
                    // Extract the total calories value
                    var parts = line.Split(':');
                    if (parts.Length == 2 && double.TryParse(parts[1].Trim(), out double totalCalories))
                    {
                        if (totalCalories < 150)
                        {
                            brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6cff9b"));
                        }
                        else if (totalCalories >= 150 && totalCalories <= 300)
                        {
                            brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ebfa84"));
                        }
                        else
                        {
                            brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f24147"));
                        }
                    }
                }
                return brush;
            }
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.displayAlterWin.Show();
        }
        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><> }
    }
}