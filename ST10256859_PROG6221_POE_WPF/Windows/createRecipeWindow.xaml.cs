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
    /// Interaction logic for createRecipeWindow.xaml
    /// </summary>
    public partial class createRecipeWindow : Window
    {
        private Window mainWindow;

        public createRecipeWindow(Window mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.mainWindow.Hide();
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            var addIngredientWindow = new addIngredientWindow(this);
            addIngredientWindow.Show();
        }

        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            var addStepWindow = new addStepWindow(this);
            addStepWindow.Show();
        }

        private void SubmitRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Your logic here
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.mainWindow.Show();
        }
    }
}
