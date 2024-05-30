// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References: List of references:
//             https://stackoverflow.com/questions/71967411/how-can-i-try-catch-an-exception-for-a-negative-number-in-c
//             https://youtu.be/QqWfw_CFR6Q?si=OWgC9KPJosQBqu5V
//             https://youtu.be/IHMmPVEOT64?si=FN64GWD1dU8C1i4E
//             https://youtu.be/aNTDJ9bnRU4?si=2f7p21l9Uz2IPAam
//             GitHub Copilot for assisting with the structure of the code.
//             Microsoft Copilot for assisting me with finding and fixing errors in the code.

using System;
using System.Collections.Generic;

namespace ST10256859_PROG6221_POE_PART1.Classes
{
    // This class is responsible for handling the steps of a recipe.
    public class Steps
    {
        public string StepDescription { get; set; }  // The description of the step.
        public int NumSteps { get; set; } = 0;  // The total number of steps. This is used for creating an array of Steps objects.

        // This is the GetSteps method of the Steps class.
        public List<Steps> GetSteps()
        {
            // The try block contains code that might throw an exception.
            try
            {
                // Prompt the user to enter the total number of steps.
                Console.Write("\nPlease enter the total number of steps: ");

                // Try to convert the user's input to an integer.
                NumSteps = Convert.ToInt32(Console.ReadLine());

                // If the number of steps is not within a reasonable range, display an error message and call the GetSteps method again.
                if (NumSteps <= 0 || NumSteps > 1000000000)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nPlease enter a valid number!\n");
                    Console.ResetColor();
                    return GetSteps();
                }
            }
            // The catch block contains code to handle the exception.
            catch (FormatException)
            {
                // If the user's input is not a valid integer, display an error message and call the GetSteps method again.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nPlease enter a number!\n");
                Console.ResetColor();
                return GetSteps();
            }

            // Create an array of Steps objects with a size equal to the number of steps.
            List<Steps> stp = new List<Steps>(NumSteps);

            // Loop through the array and prompt the user to enter the description of each step.
            for (int i = 0; i < NumSteps; i++)
            {
                Console.Write("\nPlease enter the description for step " + (i + 1) + ": ");
                string description = Console.ReadLine();

                // Create a new Steps object with the entered description and add it to the array.
                stp.Add(new Steps { StepDescription = description });
            }

            // Display a success message and return the array of Steps objects.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\nSteps successfully saved!\n\n");
            Console.ResetColor();
            return stp;
        }
    }
}

//-----------------------------------------------------------------------------END OF FILE-----------------------------------------------------------------------------