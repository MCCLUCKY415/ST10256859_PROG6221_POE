using ST10256859_PROG6221_POE_PART1.Classes;
using ST10256859_PROG6221_POE_WPF.Windows;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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

            foreach (var recipe in recipes)
            {
                TextBlock recipeSummaryBlock = new TextBlock
                {
                    Text = recipe.GetRecipeSummary(),
                    FontSize = 16,
                    Foreground = Brushes.White,
                    Margin = new Thickness(0, 10, 0, 10)
                };
                recipeDetailsPanel.Children.Add(recipeSummaryBlock);
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