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
    /// Interaction logic for DisplayAlterWindow.xaml
    /// </summary>
    public partial class DisplayAlterWindow : Window
    {
        private MainWindow mainWin;

        public DisplayAlterWindow(MainWindow mw)
        {
            InitializeComponent();

            this.mainWin = mw;
            this.mainWin.Hide();
        }

        private void DisplayAllRecipesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchForRecipeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ScaleRecipeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ResetRecipeQuantitiesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearAllRecipesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.mainWin.Show();
        }
    }
}
