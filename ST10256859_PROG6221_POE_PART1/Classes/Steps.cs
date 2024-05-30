// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References:
// - Stack Overflow: https://stackoverflow.com/questions/71967411/how-can-i-try-catch-an-exception-for-a-negative-number-in-c
// - YouTube: https://youtu.be/QqWfw_CFR6Q?si=OWgC9KPJosQBqu5V
// - YouTube: https://youtu.be/IHMmPVEOT64?si=FN64GWD1dU8C1i4E
// - YouTube: https://youtu.be/aNTDJ9bnRU4?si=2f7p21l9Uz2IPAam
// - GitHub Copilot for assisting with the structure of the code.
// - Microsoft Copilot for assisting me with finding and fixing errors in the code.

using System;
using System.Collections.Generic;

namespace ST10256859_PROG6221_POE_PART1.Classes
{
    // This class is responsible for handling the steps of a recipe.
    public class Steps
    {
        public string StepDescription { get; set; }  // The description of the step.
        public int NumSteps { get; set; } = 0;  // The total number of steps. This is used for creating an array of Steps objects.

        // Method to get user input for steps
        public List<Steps> GetSteps()
        {
            bool inputValid = false;  // Boolean to check if the user's input is valid
            List<Steps> stp = new List<Steps>();  // List to store steps

            while (!inputValid)
            {
                try
                {
                    // Prompt the user to enter the total number of steps
                    Console.Write("\nPlease enter the total number of steps: ");
                    NumSteps = Convert.ToInt32(Console.ReadLine());

                    // Validate the number of steps
                    if (NumSteps <= 0 || NumSteps > 1000000000)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\n\nPlease enter a valid number!\n\n");
                        Console.ResetColor();
                        continue;
                    }

                    // Loop through the array and prompt the user to enter the description of each step
                    for (int i = 0; i < NumSteps; i++)
                    {
                        Console.Write("\nPlease enter the description for step " + (i + 1) + ": ");
                        string description = Console.ReadLine();

                        // Create a new Steps object with the entered description and add it to the list
                        stp.Add(new Steps { StepDescription = description });
                    }

                    // Display a success message and return the list of Steps objects
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\n\nSteps successfully saved!\n\n");
                    Console.ResetColor();
                    return stp;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n\nPlease enter a number!\n");
                    Console.ResetColor();
                }
            }

            // If the user didn't enter a valid number of steps, return null
            return null;
        }
    }
}

//-----------------------------------------------------------------------------END OF FILE-----------------------------------------------------------------------------