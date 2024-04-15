// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References: List of references:
//             https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/
//             https://youtu.be/QqWfw_CFR6Q?si=OWgC9KPJosQBqu5V
//             https://youtu.be/IHMmPVEOT64?si=FN64GWD1dU8C1i4E
//             https://stackoverflow.com/questions/72696/which-is-generally-best-to-use-stringcomparison-ordinalignorecase-or-stringcom
//             GitHub Copilot for assisting with the structure of the code and helping me find and fix errors.
//             Microsoft Copilot for assisting me with finding and fixing errors in the code.

using ST10256859_PROG6221_POE_PART1.Classes;

namespace ST10256859_PROG6221_POE_PART1
{
    // This is the Program class in the ST10256859_PROG6221_POE_PART1 namespace.
    internal class Program
    {
        // This is the Main method, which is the entry point of the program.
        private static void Main(string[] args)
        {
            // Create a new instance of the RecipeProcesses class.
            RecipeProcesses recipeProcesses = new RecipeProcesses();

            // Call the MainMenu method of the RecipeProcesses object.
            // This method displays the main menu and handles the user's choices.
            recipeProcesses.MainMenu();
        }
    }
}