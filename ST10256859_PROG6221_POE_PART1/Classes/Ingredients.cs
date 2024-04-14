using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10256859_PROG6221_POE_PART1.Classes
{
    public class Ingredients
    {
        public string IngName { get; set; }
        public string IngUnitOfMeasure { get; set; }
        public double IngQuantity { get; set; }
        public double OriginalIngQuantity { get; set; }

        public Ingredients[] GetIngredients(int numIngredients)
        {
            Ingredients[] ing = new Ingredients[numIngredients];
            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write("Please enter the name of ingredient " + (i + 1) + ": ");
                string name = Console.ReadLine();

                Console.Write("Please enter the quantity of ingredient " + (i + 1) + ": ");
                double quantity = Convert.ToDouble(Console.ReadLine());

                Console.Write("Please enter the unit of measurement that will be used for ingredient " + (i + 1) + ": ");
                string measurement = Console.ReadLine();

                ing[i] = new Ingredients { IngName = name, IngQuantity = quantity, IngUnitOfMeasure = measurement, OriginalIngQuantity = quantity };
            }
            return ing;
        }
    }
}
