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

        //invokes the calorie notification that tells the user a recipe has reached 300 calories in total
        recipe.CalorieNotification += (totalCalories) =>
        {
            Console.WriteLine($"Notification: The recipe has reached {totalCalories} calories.");
        };
        bool exitMenu = false; // this variable acts as a flag to continue or exit the loop when set to true

        while (!exitMenu)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to this cool recipe app! \nPlease select one of the options");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("Note: you are allowed to enter more than one recipe. To do this, first complete steps 1,2 and \n 3 and then go to step 1 again.\n");
            Console.WriteLine("1) Enter 1 to enter the name of the recipe\n");
            Console.WriteLine("2) Enter 2 to add the ingredients\n");
            Console.WriteLine("3) Enter 3 to add the steps for your recipe\n");
            Console.WriteLine("4) Enter 4 to display your recipe\n");
            Console.WriteLine("5) Enter 5 to scale up your recipe\n");
            Console.WriteLine("6) Enter 6 to reset the recipe scale \n");
            Console.WriteLine("7) Enter 7 to display your recipe\n");
            Console.WriteLine("8) Enter 8 to exit the program");

            string choice = Console.ReadLine().Trim();

            switch (choice)
            {
                case "1":
                    recipe.SetRecipeName();
                    break;
                case "2":
                    recipe.AddIngredient();
                    break;
                case "3":
                    recipe.AddSteps();
                    break;
                case "4":
                    recipe.DisplayRecipes();
                    break;
                case "5":
                    recipe.ScaleUpRecipe();
                    break;
                case "6":
                    recipe.ResetScale();
                    break;
                case "7":
                    recipe.ClearRecipe();
                    break;
                case "8":
                    exitMenu = true;
                    break;
                default:
                    Console.WriteLine("That option is invalid. Please select again!");
                    break;
            }
        }
    }
}
//**************************************************************end of file**************************************************************//

