// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References:
// - https://youtube.com/playlist?list=PLih2KERbY1HHOOJ2C6FOrVXIwg4AZ-hk1&si=FOktN0cM5CWF7X4z
// - GitHub Copilot for assisting with the structure of the code and helping me find and fix errors.
// - ChatGPT for assisting me with finding and fixing errors in the code.

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ST10256859_PROG6221_POE_PART1.Classes;
using ST10256859_PROG6221_POE_WPF.Windows;

namespace ST10256859_PROG6221_POE_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Property to hold the list of recipes
        public List<Recipe> recipes { get; set; }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Constructor for the MainWindow class
        public MainWindow()
        {
            InitializeComponent(); // Initialize the components defined in the XAML

            recipes = new List<Recipe>(); // Initialize the recipes list
            //recipes = Recipe.GenerateRandomRecipes(); // Generate random recipes for demonstration (if lecturer wants to use he can by uncommenting the piece of code)
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Event handler for the "Create Recipe" button click
        private void CreateRecipe_Click(object sender, RoutedEventArgs e)
        {
            var createRecipeWindow = new CreateRecipeWindow(this); // Create an instance of the CreateRecipeWindow
            createRecipeWindow.Show(); // Show the CreateRecipeWindow
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Event handler for the "Display/Alter Recipe" button click
        private void DisplayAlterRecipe_Click(object sender, RoutedEventArgs e)
        {
            var displayAlterWindow = new DisplayAlterWindow(this); // Create an instance of the DisplayAlterWindow
            displayAlterWindow.Show(); // Show the DisplayAlterWindow
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Event handler for the "Exit" button click
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            // Show a message box to confirm if the user wants to close the application
            MessageBoxResult result = MessageBox.Show("Are you sure you want to close the application?", "Confirm Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // If the user clicks "Yes", close the application
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
    }
}

//-----------------------------------------------------------------------------END OF FILE-----------------------------------------------------------------------------