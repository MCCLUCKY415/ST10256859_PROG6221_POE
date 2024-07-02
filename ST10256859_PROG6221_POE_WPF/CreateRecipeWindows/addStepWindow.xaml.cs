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
    /// Interaction logic for AddStepWindow.xaml
    /// </summary>
    public partial class AddStepWindow : Window
    {
        private CreateRecipeWindow createRecipeWin;

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        public AddStepWindow(CreateRecipeWindow crw)
        {
            InitializeComponent();
            this.createRecipeWin = crw;
            this.createRecipeWin.Hide();
        }

        //<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>
        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            string newStepDescription = stepDescriptionTextBox.Text;

            if (string.IsNullOrEmpty(newStepDescription))
            {
                MessageBox.Show("Please enter a step description.");
                return;
            }
            createRecipeWin.newSteps.Add(new Step(newStepDescription));
            stepDescriptionTextBox.Text = "";
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
