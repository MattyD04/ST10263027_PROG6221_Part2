using RecipeManagerPOE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Program
{
    static void Main(string[] args)
    {
        Recipe recipe = new Recipe();
        bool exitMenu = false; // this variable acts as a flag to continue or exit the loop when set to true

        while (!exitMenu)
        {
            Console.WriteLine("Welcome to this cool recipe app! \nPlease select one of the options\n********************************************");
            Console.WriteLine("1) Add the ingredients for your recipe\n");
            Console.WriteLine("2) Add the steps for your recipe\n");
            Console.WriteLine("3) Display your recipe\n");
            Console.WriteLine("4) Scale your recipe\n");
            Console.WriteLine("5) Reset your recipe\n");
            Console.WriteLine("6) Exit the program");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    recipe.AddIngredient();
                    break;
                case "2":
                    recipe.AddSteps();
                    break;
                case "3":
                    recipe.DisplayRecipe();
                    break;
                case "4":
                    recipe.ScaleRecipe();
                    break;
                case "5":
                    recipe.ResetRecipe();
                    break;
                case "6":
                    exitMenu = true;
                    break;
                default:
                    Console.WriteLine("That option is invalid. Please select again!");
                    break;
            }
        }
    }
}


