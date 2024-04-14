using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10256859_PROG6221_POE_PART1.Classes
{
    public class Steps
    {
        public string StepDescription { get; set; }
        public int NumSteps { get; set; } = 0;

        public Steps[] GetSteps()
        {
            Console.Write("Please enter the total number of steps: ");
            NumSteps = Convert.ToInt32(Console.ReadLine());

            Steps[] stp = new Steps[NumSteps];
            for (int i = 0; i < NumSteps; i++)
            {
                Console.Write("Please enter a description for step " + (i + 1) + ": ");
                string description = Console.ReadLine();

                stp[i] = new Steps { StepDescription = description };
            }
            return stp;
        }
    }
}