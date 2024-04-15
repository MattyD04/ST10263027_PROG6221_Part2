﻿using RecipeManagerPOE;
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

            Console.WriteLine("Welcome to this cool recipe app! \nPlease select one of the options\n********************************************");
            Console.WriteLine("1) Add the ingredients for your recipe\n");
            Console.WriteLine("2) Add the steps for your recipe\n");
            Console.WriteLine("3) Display your recipe\n");
            Console.WriteLine("4) Scale up your recipe\n");
            Console.WriteLine("5) Scale down your recipe\n");
            Console.WriteLine("6) Reset your recipe\n");
            Console.WriteLine("7) Exit the program");

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
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "4":
                    recipe.ScaleUpRecipe();
                    break;
                case "5":
                    recipe.ScaleDownRecipe();
                    break;
                case "6":
                    recipe.ResetRecipe();
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


