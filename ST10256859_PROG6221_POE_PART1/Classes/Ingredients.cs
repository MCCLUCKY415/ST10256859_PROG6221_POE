using System;

namespace ST10256859_PROG6221_POE_PART1.Classes
{
    public class Ingredients
    {
        public string IngName { get; set; }
        public string IngUnitOfMeasure { get; set; }
        public double IngQuantity { get; set; }
        public double OriginalIngQuantity { get; set; }
        public int NumIngredients { get; set; } = 0;

        public Ingredients[] GetIngredients()
        {
            Console.Write("Please enter the total number of ingredients that will be used: ");
            NumIngredients = Convert.ToInt32(Console.ReadLine());

            Ingredients[] ing = new Ingredients[NumIngredients];
            for (int i = 0; i < NumIngredients; i++)
            {
                Console.Write("Please enter the name of ingredient " + (i + 1) + ": ");
                string name = Console.ReadLine();

                Console.Write("Please enter the quantity of ingredient " + (i + 1) + ": ");
                double quantity = Convert.ToDouble(Console.ReadLine());

                Console.Write("Please enter the unit of measurement that will be used for ingredient (e.g. a tablespoon) " + (i + 1) + ": ");
                string measurement = Console.ReadLine();

                ing[i] = new Ingredients { IngName = name, IngQuantity = quantity, IngUnitOfMeasure = measurement, OriginalIngQuantity = quantity };
            }
            return ing;
        }
    }
}