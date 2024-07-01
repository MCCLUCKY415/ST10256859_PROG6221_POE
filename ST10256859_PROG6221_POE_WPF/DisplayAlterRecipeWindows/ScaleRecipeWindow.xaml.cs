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

namespace ST10256859_PROG6221_POE_WPF.DisplayAlterRecipeWindows
{
    /// <summary>
    /// Interaction logic for ScaleRecipeWindow.xaml
    /// </summary>
    public partial class ScaleRecipeWindow : Window
    {
        private DisplayAlterWindow displayAlterWin;

        public ScaleRecipeWindow(DisplayAlterWindow daw)
        {
            InitializeComponent();

            this.displayAlterWin = daw;
            this.displayAlterWin.Hide();
        }

        private void halfScaleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void doubleScaleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tripleScaleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void resetQuantitiesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.displayAlterWin.Show();
        }
    }
}
