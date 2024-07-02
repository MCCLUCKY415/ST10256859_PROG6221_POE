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
        private MainWindow mainWin;
        
        public List<Step> newSteps { get; set; }
        public List<Ingredient> newIngredients { get; set; } //change the Ingredient class
        public string recipeName;

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        public CreateRecipeWindow(MainWindow mw)
        {
            InitializeComponent();
            newSteps = new List<Step>();
            newIngredients = new List<Ingredient>();

            this.mainWin = mw;
            this.mainWin.Hide();
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            var addIngredientWindow = new AddIngredientWindow(this);
            addIngredientWindow.Show();
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            var addStepWindow = new AddStepWindow(this);
            addStepWindow.Show();
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        private void SubmitRecipe_Click(object sender, RoutedEventArgs e)
        {
            string newRecipeName = recipeNameTextBox.Text;

            if (string.IsNullOrEmpty(newRecipeName))
            {
                MessageBox.Show("Please enter a recipe name.");
                return;
            }

            if (newIngredients.Count == 0)
            {
                MessageBox.Show("Please add at least one ingredient.");
                return;
            }

            if (newSteps.Count == 0)
            {
                MessageBox.Show("Please add at least one step.");
                return;
            }

            mainWin.recipes.Add(new Recipe(newRecipeName, newIngredients, newSteps));
            this.Close();
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.mainWin.Show();
        }
        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
    }
}
