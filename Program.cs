using RecipeManagerPOE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Name: Matthew Darlow
/// Student number: ST10263027
/// Module code: PROG6221
/// </summary>
internal class Program
{
    static void Main(string[] args) //main method executes the code
    {
        Recipe recipe = new Recipe();
        bool exitMenu = false; // this variable acts as a flag to continue or exit the loop when set to true

        while (!exitMenu)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to this cool recipe app! \nPlease select one of the options\n********************************************");
            Console.WriteLine("Note: you are allowed to enter more than one recipe. To do this you must first complete steps 1 and 2 and then proceed \n back to step 1 to enter another recipe.");
            Console.WriteLine("1) Enter the name of the recipe and add the ingredients\n");
            Console.WriteLine("2) Add the steps for your recipe\n");
            Console.WriteLine("3) Display your recipe\n");
            Console.WriteLine("4) Scale up your recipe\n");
            Console.WriteLine("5) Reset scale \n");
            Console.WriteLine("6) Clear your recipe\n");
            Console.WriteLine("7) Exit the program");

            string choice = Console.ReadLine().Trim();

            switch (choice)
            {
                case "1":
                    recipe.AddIngredient();
                    break;
                case "2":
                    recipe.AddSteps();
                    break;
                case "3":
                    recipe.DisplayRecipes();
                    break;
                case "4":
                    recipe.ScaleUpRecipe();
                    break;
                case "5":
                    recipe.ResetScale();
                    break;
                case "6":
                    recipe.ClearRecipe();
                    break;
                case "7":
                    exitMenu = true;
                    break;
                default:
                    Console.WriteLine("That option is invalid. Please select again!");
                    break;
            }
        }
    }
}
//*****************************************************end of file************************************//

