// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References:
// - https://youtube.com/playlist?list=PLih2KERbY1HHOOJ2C6FOrVXIwg4AZ-hk1&si=FOktN0cM5CWF7X4z
// - GitHub Copilot for assisting with the structure of the code and helping me find and fix errors.
// - ChatGPT for assisting me with finding and fixing errors in the code.

using ST10256859_PROG6221_POE_PART1.Classes;
using ST10256859_PROG6221_POE_WPF.CreateRecipeWindows;
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
    /// Interaction logic for CreateRecipeWindow.xaml
    /// </summary>
    public partial class CreateRecipeWindow : Window
    {
        // Reference to the MainWindow instance
        private MainWindow mainWin;

        // Lists to store new steps and ingredients for the recipe
        public List<Step> newSteps { get; set; }
        public List<Ingredient> newIngredients { get; set; }
        public string recipeName;

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Constructor for CreateRecipeWindow
        public CreateRecipeWindow(MainWindow mw)
        {
            InitializeComponent(); // Initialize the components defined in the XAML

            newSteps = new List<Step>(); // Initialize the list of steps
            newIngredients = new List<Ingredient>(); // Initialize the list of ingredients

            this.mainWin = mw; // Store the reference to the MainWindow instance
            this.mainWin.Hide(); // Hide the MainWindow
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Event handler for the "Add Ingredient" button click
        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            var addIngredientWindow = new AddIngredientWindow(this); // Create an instance of the AddIngredientWindow
            addIngredientWindow.Show(); // Show the AddIngredientWindow
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Event handler for the "Add Step" button click
        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            var addStepWindow = new AddStepWindow(this); // Create an instance of the AddStepWindow
            addStepWindow.Show(); // Show the AddStepWindow
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Event handler for the "Submit Recipe" button click
        private void SubmitRecipe_Click(object sender, RoutedEventArgs e)
        {
            string newRecipeName = recipeNameTextBox.Text; // Get the recipe name from the textbox

            // Check if the recipe name is provided
            if (string.IsNullOrEmpty(newRecipeName))
            {
                MessageBox.Show("Please enter a recipe name.");
                return;
            }

            // Check if at least one ingredient is added
            if (newIngredients.Count == 0)
            {
                MessageBox.Show("Please add at least one ingredient.");
                return;
            }

            // Check if at least one step is added
            if (newSteps.Count == 0)
            {
                MessageBox.Show("Please add at least one step.");
                return;
            }

            // Add the new recipe to the list of recipes in the MainWindow
            mainWin.recipes.Add(new Recipe(newRecipeName, newIngredients, newSteps));
            this.Close(); // Close the CreateRecipeWindow
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Override the OnClosed method to handle window closing events
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.mainWin.Show(); // Show the MainWindow when this window is closed
        }
        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
    }
}

//-----------------------------------------------------------------------------END OF FILE-----------------------------------------------------------------------------