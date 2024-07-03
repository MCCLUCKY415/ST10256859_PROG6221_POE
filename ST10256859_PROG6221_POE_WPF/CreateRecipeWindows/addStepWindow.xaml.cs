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
    /// Interaction logic for AddStepWindow.xaml
    /// </summary>
    public partial class AddStepWindow : Window
    {
        private CreateRecipeWindow createRecipeWin; // Reference to the CreateRecipeWindow instance

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Constructor for AddStepWindow
        public AddStepWindow(CreateRecipeWindow crw)
        {
            InitializeComponent(); // Initialize the components defined in the XAML

            this.createRecipeWin = crw; // Store the reference to the CreateRecipeWindow instance
            this.createRecipeWin.Hide(); // Hide the CreateRecipeWindow while this window is open
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        // Event handler for the "Add Step" button click
        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the step description from the TextBox
            string newStepDescription = stepDescriptionTextBox.Text;

            // Check if the step description is empty
            if (string.IsNullOrEmpty(newStepDescription))
            {
                // Show an error message if the step description is empty
                MessageBox.Show("Please enter a step description.");
                return;
            }

            // Add the new step to the list of steps in CreateRecipeWindow
            createRecipeWin.newSteps.Add(new Step(newStepDescription));

            // Clear the TextBox for future input
            stepDescriptionTextBox.Text = "";

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