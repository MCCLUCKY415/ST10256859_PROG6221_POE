// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References: List of references:
//             https://www.youtube.com/watch?v=BstOEzntT1hQzk&lsist=LL&ingdenx=sd1&t=1294s
//             https://learn.microsoft.com/en-us/dotnet/desktop/winf/advanced/how-to-windows-form?view=netframeworkdesktop-4.8
//             https://learn.microsoft.com/en-us/dotnet/api/system.graphics?view=windowsdesktop

using System;

namespace ST10256859_PROG6221_POE_PART1.Classes
{
    public class RecipeProcesses
    {
        private Ingredients ing = new Ingredients();
        private Steps stp = new Steps();
        private AlteringRecipeProcesses altRecipe = new AlteringRecipeProcesses();

        public void DisplayRecipe(Ingredients[] ing, Steps[] steps)
        {
            if (ing != null && ing.Length > 0 && steps != null && steps.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n\n\n****************************");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("          RECIPE            ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("****************************");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Ingredients:");
                for (int i = 0; i < ing.Length; i++)
                {
                    Console.WriteLine("~ " + ing[i].IngQuantity + " " + ing[i].IngUnitOfMeasure + " " + ing[i].IngName);
                }

                Console.WriteLine("\nSteps:");
                for (int i = 0; i < steps.Length; i++)
                {
                    Console.WriteLine("Step " + (i + 1) + ") " + steps[i].StepDescription);
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("****************************\n\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nNo recipe to display. Please enter a new recipe first!\n\n");
                Console.ResetColor();
            }
        }

        public void MainMenu()
        {
            Ingredients[] ing = new Ingredients[0];
            Steps[] stp = new Steps[0];
            int choice;
            while (true)
            {
                try
                {
                    Console.WriteLine("\n****************************");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("            MENU            ");
                    Console.ResetColor();
                    Console.WriteLine("****************************");
                    Console.WriteLine("1) Enter a new recipe");
                    Console.WriteLine("2) Display recipe");
                    Console.WriteLine("3) Scale recipe");
                    Console.WriteLine("4) Reset quantities");
                    Console.WriteLine("5) Clear all data");
                    Console.WriteLine("6) Exit");
                    Console.WriteLine("****************************");

                    Console.Write("Enter your choice: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nPlease enter a number that correlates to the menu!\n");
                    Console.ResetColor();
                    continue;
                }
                if (choice == 1)
                {
                    ing = this.ing.GetIngredients();
                    stp = this.stp.GetSteps();
                }
                else if (choice == 2)
                {
                    DisplayRecipe(ing, stp);
                }
                else if (choice == 3)
                {
                    if (ing.Length == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nNo recipe to scale. Please enter a new recipe first!\n\n");
                        Console.ResetColor();
                        continue;
                    }
                    while (true)
                    {
                        Console.Write("\n\nPlease enter the number you would like to scale the recipe by (Put in '0,5' for half, '2' for double or '3' for triple): ");
                        try
                        {
                            double factor = Convert.ToDouble(Console.ReadLine());
                            if (factor != 0.5 && factor != 2 && factor != 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\n\nInvalid input. Please enter '0,5' for half, '2' for double, or '3' for triple!\n\n");
                                Console.ResetColor();
                                continue;
                            }
                            altRecipe.ScaleRecipe(ing, factor);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n\n\nRecipe successfully scaled! View changes by going into the 'Display recipe section'\n\n");
                            Console.ResetColor();
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\n\nInvalid input. Please enter '0,5' for half, '2' for double, or '3' for triple!\n\n");
                            Console.ResetColor();
                        }
                    }
                }
                else if (choice == 4)
                {
                    if (ing.Length == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nThere is no recipe to reset. Please enter a new recipe first!\n\n");
                        Console.ResetColor();
                        continue;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\n\nAre you sure you want to reset all quantities? (yes/no): ");
                    Console.ResetColor();
                    string confirm = Console.ReadLine();
                    if (confirm.Equals("yes", StringComparison.OrdinalIgnoreCase) || confirm.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        altRecipe.ResetNewQuantities(ing);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\n\nQuantities successfully reset!\n\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nResetting quantities cancelled.\n");
                        Console.ResetColor();
                    }
                }
                else if (choice == 5)
                {
                    if (ing.Length == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nThere is no recipe to clear. Please enter a new recipe first!\n\n");
                        Console.ResetColor();
                        continue;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\n\nAre you sure you want to clear all recipe data? (yes/no): ");
                    Console.ResetColor();
                    string confirm = Console.ReadLine();
                    if (confirm.Equals("yes", StringComparison.OrdinalIgnoreCase) || confirm.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        altRecipe.ClearAllData();
                        ing = new Ingredients[0];
                        stp = new Steps[0];
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\n\nRecipe data successfully cleared!\n\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nData clearing cancelled.\n");
                        Console.ResetColor();
                    }
                }
                else if (choice == 6)
                {
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nPlease enter a number that correlates to the menu!\n");
                    Console.ResetColor();
                    continue;
                }
            }
        }
    }
}