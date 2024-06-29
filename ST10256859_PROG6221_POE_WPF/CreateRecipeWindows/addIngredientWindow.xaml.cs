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
    /// Interaction logic for addIngredientWindow.xaml
    /// </summary>
    public partial class addIngredientWindow : Window
    {
        private createRecipeWindow createRecipeWin;

        public addIngredientWindow(createRecipeWindow crw)
        {
            InitializeComponent();
            this.createRecipeWin = crw;
            this.createRecipeWin.Hide();
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {


        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.createRecipeWin.Show();
        }
    }
}
