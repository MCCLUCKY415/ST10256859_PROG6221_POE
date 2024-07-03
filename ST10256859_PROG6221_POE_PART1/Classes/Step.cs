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
    public class Step
    {
        // Property to store the description of the step.
        public string StepDescription { get; set; }

        // Constructor to initialize the step with a description.
        // Parameter:
        //   stepDescription: A string containing the description of the step.
        public Step(string stepDescription)
        {
            StepDescription = stepDescription; // Assign the provided description to the StepDescription property.
        }
    }
}

//-----------------------------------------------------------------------------END OF FILE-----------------------------------------------------------------------------