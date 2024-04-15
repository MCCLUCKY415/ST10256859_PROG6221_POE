﻿using System;

namespace ST10256859_PROG6221_POE_PART1.Classes
{
    public class Steps
    {
        public string StepDescription { get; set; }
        public int NumSteps { get; set; } = 0;

        public Steps[] GetSteps()
        {
            try
            {
                Console.Write("\nPlease enter the total number of steps: ");
                NumSteps = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nPlease enter a number!");
                Console.ResetColor();
                return GetSteps();
            }
            Steps[] stp = new Steps[NumSteps];
            for (int i = 0; i < NumSteps; i++)
            {
                Console.Write("\nPlease enter the description for step " + (i + 1) + ": ");
                string description = Console.ReadLine();

                stp[i] = new Steps { StepDescription = description };
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\nSteps successfully saved!\n\n");
            Console.ResetColor();
            return stp;
        }
    }
}