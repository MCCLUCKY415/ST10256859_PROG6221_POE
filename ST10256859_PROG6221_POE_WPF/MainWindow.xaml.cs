﻿using System;
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
using ST10256859_PROG6221_POE_WPF.Windows;

namespace ST10256859_PROG6221_POE_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateRecipe_Click(object sender, RoutedEventArgs e)
        {
            var createRecipeWindow = new CreateRecipeWindow(this);
            createRecipeWindow.Show();
        }

        private void DisplayAlterRecipe_Click(object sender, RoutedEventArgs e)
        {
            var displayAlterWindow = new DisplayAlterWindow(this); 
            displayAlterWindow.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
