using System;

namespace ST10256859_PROG6221_POE_PART1.Classes
{
    public class RecipeProcessing
    {


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
            IngQuantity = Convert.ToInt32(Console.ReadLine());
            return IngQuantity.ToString();
        }

        public string GetUnitOfIngredients()
        {
            Console.WriteLine("Please enter the unit of measurement you'll be using for the ingredient (e.g. a tablespoon of sugar): ");
            IngUnitOfMeasure = Console.ReadLine();
            return IngUnitOfMeasure;
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