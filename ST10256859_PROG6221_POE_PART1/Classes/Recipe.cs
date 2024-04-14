using System;

namespace ST10256859_PROG6221_POE_PART1.Classes
{
    public class Recipe
    {
        public string IngName { get; set; }
        public string IngUnit { get; set; }
        public string StepDescription { get; set; }
        public int NumOfIng { get; set; }
        public double IngQty { get; set; }
        public int NumOfSteps { get; set; }

        public void GetNumberOfIngredients()
        {
            Console.WriteLine("Please enter the number of ingredients for this recipe: ");
            NumOfIng = Convert.ToInt32(Console.ReadLine());
        }

        public string GetNameOfIngredients()
        {
            Console.WriteLine("Please enter the name of the ingredient you would like to add: ");
            IngName = Console.ReadLine();
            return IngName;
        }

        public string GetQuantityOfIngredients()
        {
            Console.WriteLine("Please enter the quantity of the ingredient you would like to add: ");
            IngQty = Convert.ToInt32(Console.ReadLine());
            return IngQty.ToString();
        }

        public string GetUnitOfIngredients()
        {
            Console.WriteLine("Please enter the unit of measurement you'll be using for the ingredient (e.g. a tablespoon of sugar): ");
            IngUnit = Console.ReadLine();
            return IngUnit;
        }

        public void GetNumberOfSteps()
        {
            Console.WriteLine("Please enter the number of steps for this recipe: ");
            NumOfSteps = Convert.ToInt32(Console.ReadLine());
        }

        public void GetDescriptionOfSteps()
        {
            Console.WriteLine("Please enter a description of the step you would like to add: ");
            StepDescription = Console.ReadLine();
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("Recipe Name: ");
            Console.WriteLine("Number of Ingredients: ");
            Console.WriteLine("Ingredients: ");
        }
    }
}