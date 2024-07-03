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
using System.Windows;
using System.Windows.Controls;

namespace ST10256859_PROG6221_POE_WPF.CreateRecipeWindows
{
    /// <summary>
    /// Interaction logic for AddIngredientWindow.xaml
    /// </summary>
    public partial class AddIngredientWindow : Window
    {
        private CreateRecipeWindow createRecipeWin; // Reference to the CreateRecipeWindow instance

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Constructor for AddIngredientWindow
        public AddIngredientWindow(CreateRecipeWindow crw)
        {
            InitializeComponent(); // Initialize the components defined in the XAML

            this.createRecipeWin = crw; // Store the reference to the CreateRecipeWindow instance
            this.createRecipeWin.Hide(); // Hide the CreateRecipeWindow while this window is open
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Event handler for the "Add Ingredient" button click
        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the ingredient name from the TextBox
            string newIngredientName = ingredientNameTextBox.Text;

            // Check if the ingredient name is empty
            if (string.IsNullOrEmpty(newIngredientName))
            {
                // Show an error message if the ingredient name is empty
                MessageBox.Show("Please enter an ingredient name.");
                return;
            }

            // Get the unit of measurement from the TextBox
            string newIngredientUnitOfMeasurement = unitOfMeasurementTextBox.Text;

            // Check if the unit of measurement is empty
            if (string.IsNullOrEmpty(newIngredientUnitOfMeasurement))
            {
                // Show an error message if the unit of measurement is empty
                MessageBox.Show("Please enter a unit of measurement.");
                return;
            }

            // Get the ingredient quantity from the TextBox and validate it
            double newIngredientQuantity;
            if (!double.TryParse(quantityTextBox.Text, out newIngredientQuantity))
            {
                // Show an error message if the quantity is not a valid number
                MessageBox.Show("Please enter a valid number of measurement.");
                return;
            }

            // Get the number of calories from the TextBox and validate it
            double newIngredientNumberOfCalories;
            if (!double.TryParse(caloriesTextBox.Text, out newIngredientNumberOfCalories))
            {
                // Show an error message if the calories are not a valid number
                MessageBox.Show("Please enter a valid number of calories.");
                return;
            }

            // Get the food group from the ComboBox
            string newIngredientFoodGroup = foodGroupComboBox.Text;

            // Check if the food group is empty
            if (string.IsNullOrEmpty(newIngredientFoodGroup))
            {
                // Show an error message if no food group is selected
                MessageBox.Show("Please select a food group.");
                return;
            }

            // Create the new ingredient
            Ingredient newIngredient = new Ingredient(newIngredientName, newIngredientUnitOfMeasurement, newIngredientQuantity, newIngredientNumberOfCalories, newIngredientFoodGroup);

            // Add the new ingredient to the list in CreateRecipeWindow
            createRecipeWin.newIngredients.Add(newIngredient);

            // Calculate the total calories of the recipe
            double totalCalories = createRecipeWin.newIngredients.Sum(ing => ing.Calories);

            // Check if the total calories exceed 300
            if (totalCalories > 300)
            {
                // Show a warning message if the total calories exceed 300
                MessageBox.Show($"Warning: The total calories for this recipe now exceed 300 (Current total: {totalCalories}).", "Calorie Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            // Close the current window
            this.Close();
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Override the OnClosed method to handle window closing events
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.createRecipeWin.Show(); // Show the CreateRecipeWindow when this window is closed
        }
        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
    }
}

//-----------------------------------------------------------------------------END OF FILE-----------------------------------------------------------------------------