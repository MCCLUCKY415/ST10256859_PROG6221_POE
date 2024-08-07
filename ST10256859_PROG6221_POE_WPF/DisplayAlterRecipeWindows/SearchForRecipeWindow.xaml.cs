﻿// Dhiren Ruthenavelu
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
    /// Interaction logic for SearchForRecipeWindow.xaml
    /// </summary>
    public partial class SearchForRecipeWindow : Window
    {
        private DisplayAlterWindow displayAlterWin;

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Constructor for SearchForRecipeWindow
        public SearchForRecipeWindow(DisplayAlterWindow daw)
        {
            InitializeComponent(); // Initialize the components defined in the XAML

            this.displayAlterWin = daw; // Store the reference to the DisplayAlterWindow instance
            this.displayAlterWin.Hide(); // Hide the DisplayAlterWindow
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Event handler for the "Search for Recipe" button click
        private void searchForRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Get search criteria from the input controls
            string ingredientName = searchIngredientNameTextBox.Text;
            string foodGroup = foodGroupComboBox.Text;
            string maxCalories = searchMaxCaloriesTextBox.Text;
            List<Recipe> searchResults = new List<Recipe>();

            // Clear the recipe details panel before displaying new results
            recipeDetailsPanel.Children.Clear();
            if (ingredientName == "" && foodGroup == "" && maxCalories == "")
            {
                MessageBox.Show("Please enter at least one search criteria."); // Show a message if no criteria is provided
            }
            else
            {
                // Call the search function in DisplayAlterWindow to get the search results
                searchResults = displayAlterWin.SearchForRecipes(ingredientName, foodGroup, maxCalories);

                if (searchResults.Count == 0)
                {
                    // Display a message if no recipes are found
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
                                Foreground = GetLineForeground(line), // Apply colored text based on conditions
                                Margin = new Thickness(20, 0, 0, 0) // Adjust margin for indentation
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
                                Foreground = GetLineForeground(line), // Apply colored text based on conditions
                                Margin = new Thickness(0, 0, 0, 5) // Adjust margin for non-step lines
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
                        // Check if the line is in the correct format
                        if (parts.Length == 2 && double.TryParse(parts[1].Trim(), out double totalCalories))
                        {
                            // Set the foreground color based on total calories
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