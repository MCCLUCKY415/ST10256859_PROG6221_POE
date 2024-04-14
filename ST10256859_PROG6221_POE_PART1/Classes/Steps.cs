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
        public int NumOfSteps { get; set; }

        public Steps[] GetSteps(int numSteps)
        {
            Steps[] stp = new Steps[numSteps];
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write("Please enter a description for step " + (i + 1) + ": ");
                string description = Console.ReadLine();

                stp[i] = new Steps { StepDescription = description };
            }
            return stp;
        }
    }
}
