﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace ST10256859_PROG6221_POE_PART1.Classes
{
    public class AlteringRecipeProcesses
    {
        private Ingredients ing = new Ingredients();
        private Steps stp = new Steps();

        public void ScaleRecipe(Ingredients[] ing, double factor)
        {
            if (ing != null && ing.Length > 0)
            {
                foreach (var ingredient in ing)
                {
                    ingredient.IngQuantity = ingredient.OriginalIngQuantity * factor;
                }
            }
            else
            {
                Console.WriteLine("No ingredients to scale. Please enter a new recipe first.");
            }
        }

        public void ResetNewQuantities(Ingredients[] ing)
        {
            if (ing != null && ing.Length > 0)
            {
                foreach (var ingredient in ing)
                {
                    ingredient.IngQuantity = ingredient.OriginalIngQuantity;
                }
            }
            else
            {
                Console.WriteLine("No ingredients to reset. Please enter a new recipe first.");
            }
        }

        public void ClearAllData()
        {
            ing = new Ingredients();
            stp = new Steps();
        }
    }
}