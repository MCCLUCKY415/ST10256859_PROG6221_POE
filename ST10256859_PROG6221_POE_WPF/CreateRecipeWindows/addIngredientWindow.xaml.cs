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

namespace ST10256859_PROG6221_POE_WPF.CreateRecipeWindows
{
    /// <summary>
    /// Interaction logic for AddIngredientWindow.xaml
    /// </summary>
    public partial class AddIngredientWindow : Window
    {
        private CreateRecipeWindow createRecipeWin;

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        public AddIngredientWindow(CreateRecipeWindow crw)
        {
            InitializeComponent();
            this.createRecipeWin = crw;
            this.createRecipeWin.Hide();
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            string newIngredientName = ingredientNameTextBox.Text;
            if (string.IsNullOrEmpty(newIngredientName))
            {
                MessageBox.Show("Please enter an ingredient name.");
                return;
            }

            string newIngredientUnitOfMeasurement = unitOfMeasurementTextBox.Text;
            if (string.IsNullOrEmpty(newIngredientUnitOfMeasurement))
            {
                MessageBox.Show("Please enter a unit of measurement.");
                return;
            }

            double newIngredientQuantity;
            if (!double.TryParse(quantityTextBox.Text,out newIngredientQuantity))
            {
               MessageBox.Show("Please enter a valid number of measurement.");
                return;
            }

            double newIngredientNumberOfCalories;
            if (!double.TryParse(caloriesTextBox.Text, out newIngredientNumberOfCalories))
            {
                MessageBox.Show("Please enter a valid number of calories.");
                return;
            }
            
            string newIngredientFoodGroup = foodGroupComboBox.Text;
            if (string.IsNullOrEmpty(newIngredientFoodGroup))
            {
                MessageBox.Show("Please select a food group.");
                return;
            }

            // Create the new ingredient
            Ingredient newIngredient = new Ingredient(newIngredientName, newIngredientUnitOfMeasurement, newIngredientQuantity, newIngredientNumberOfCalories, newIngredientFoodGroup);

            // Add the new ingredient to the list
            createRecipeWin.newIngredients.Add(newIngredient);

            // Calculate the total calories of the recipe
            double totalCalories = createRecipeWin.newIngredients.Sum(ing => ing.Calories);

            // Check if the total calories exceed 300
            if (totalCalories > 300)
            {
                MessageBox.Show($"Warning: The total calories for this recipe now exceed 300 (Current total: {totalCalories}).", "Calorie Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            this.Close();
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.createRecipeWin.Show();
        }
        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
    }
}
