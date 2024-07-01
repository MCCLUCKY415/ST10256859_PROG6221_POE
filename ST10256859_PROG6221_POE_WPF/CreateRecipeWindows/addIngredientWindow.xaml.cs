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

        public AddIngredientWindow(CreateRecipeWindow crw)
        {
            InitializeComponent();
            this.createRecipeWin = crw;
            this.createRecipeWin.Hide();
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            string newIngredientName = ingredientNameTextBox.Text;
            string newIngredientUnitOfMeasurement = unitOfMeasurementTextBox.Text;
            string newIngredientQuantity = quantityTextBox.Text;
            string newIngredientNumberOfCalories = caloriesTextBox.Text;
            string newIngredientFoodGroup = foodGroupComboBox.Text;

            if (string.IsNullOrEmpty(newIngredientName) || string.IsNullOrEmpty(newIngredientUnitOfMeasurement) || string.IsNullOrEmpty(newIngredientQuantity) || string.IsNullOrEmpty(newIngredientNumberOfCalories) || string.IsNullOrEmpty(newIngredientFoodGroup))
            {
                MessageBox.Show("Please enter all ingredient details.");
                return;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.createRecipeWin.Show();
        }
    }
}
