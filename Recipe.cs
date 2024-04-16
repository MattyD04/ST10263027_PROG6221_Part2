using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

/*
 * References: 
 * https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/
 * https://www.geeksforgeeks.org/console-readkey-method-in-c-sharp/
 */
// utilised Claude AI for debugging and to mainly fix a debugging target error
namespace RecipeManagerPOE
{
    internal class Recipe
    {
        public string ingredient { get; set; }//this variable is used to create string representation of the ingredient
        public int NumIng { get; set; } //variable to store the amount of ingredients will be needed for the recipe
        public string IngName { get; set; } //the name of the ingredient
        public double IngQuant { get; set; } //variable to store quantity of ingredients used
        public string unit { get; set; } //unit of measurement used for the ingredients
        public int NumStep { get; set; } //variable for the number of recipe steps
        public string Step { get; set; } //variable for the step in the recipe
        public List<string> StepsLists { get; set; } = new List<string>(); //this list will be used to store the steps for the recipe
        public List<string> IngredientsList { get; set; } = new List<string>(); //array list to store the ingredients

        public void AddIngredient() //this method adds the ingredients to the IngredientsList
        {
            Console.WriteLine("Please enter the number of ingredients you wish to include in this recipe!");
            NumIng = int.Parse(Console.ReadLine()); // Parse the user input from string to int

            for (int i = 0; i < NumIng; i++)
            {
                Console.WriteLine("Enter the ingredient name: ");
                IngName = Console.ReadLine();
                Console.WriteLine("Enter the quantity of the ingredient: ");
                IngQuant = double.Parse(Console.ReadLine()); // Parse the user input from string to double
                Console.WriteLine("Enter the unit of measurement: ");
                unit = Console.ReadLine();
                ingredient = $"{IngQuant} {unit} of {IngName}"; //creates a string literal using string manipulation
                IngredientsList.Add(ingredient);
            }
        }
        //****************************************************************************//
        public void AddSteps() //this method adds the steps to the StepsLists 
        {
            Console.WriteLine("Please enter the number of steps for the recipe! ");
            NumStep = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the recipe steps: ");
            for (int i = 0; i < NumStep; i++)
            {
                Step = Console.ReadLine().Trim();

                StepsLists.Add(Step);
            }
        }
        //****************************************************************************//
        public void ResetRecipe() //debugged and corrected by Claude AI
        //this method clears all the recipe data
        {
            Console.Write("Are you sure you want to clear all recipe data? (y/n) ");
            ConsoleKeyInfo userInput = Console.ReadKey();
            Console.WriteLine();
            if (userInput.Key == ConsoleKey.Y)
            {
                IngredientsList.Clear();
                StepsLists.Clear();
                Console.WriteLine("Recipe data has been cleared.");
            }
            else
            {
                Console.WriteLine("Recipe data has not been cleared.");
            }
        }
        //****************************************************************************//
        public void DisplayRecipe() //debugged and corrected by Claude AI
        // this method displays the ingredients and steps of the recipe
        {
            Console.WriteLine("Your recipe");
            Console.WriteLine("Ingredients: ");
            foreach (var ingredient in IngredientsList)
            {
                Console.WriteLine(ingredient);
            }
            Console.WriteLine("**************************");
            Console.WriteLine("Steps: ");
            for (int i = 0; i < StepsLists.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {StepsLists[i]}");
            }
            Console.WriteLine("**************************");
        }
        //****************************************************************************//
        public void ScaleUpRecipe() // this method allows the user to scale up the recipe (Corrected by Claude AI)
        {
            Console.WriteLine("Select the option you want to scale your recipe up by:");
            Console.WriteLine("1) Scale up by a factor of 0.5");
            Console.WriteLine("2) Scale up by a factor of 2");
            Console.WriteLine("3) Scale up by a factor of 3");

            string choice = Console.ReadLine();

            for (int i = 0; i < IngredientsList.Count; i++)
            {
                int spaceIndex = IngredientsList[i].IndexOf(" ");
                double quantity = double.Parse(IngredientsList[i].Substring(0, spaceIndex));

                switch (choice)
                {
                    case "1":
                        quantity *= 0.5;
                        break;
                    case "2":
                        quantity *= 2;
                        break;
                    case "3":
                        quantity *= 3;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                IngredientsList[i] = $"{quantity:F2} {IngredientsList[i].Substring(spaceIndex + 1)}";
            }
        }
        //****************************************************************************//
        public void ScaleDownRecipe() // this method allows the user to scale down the recipe (Corrected by Claude AI)
        {
            Console.WriteLine("Select the option you want to scale your recipe down by:");
            Console.WriteLine("1) Scale down by a factor of 0.5");
            Console.WriteLine("2) Scale down by a factor of 2");
            Console.WriteLine("3) Scale down by a factor of 3");

            string choice = Console.ReadLine();

            for (int i = 0; i < IngredientsList.Count; i++)
            {
                int spaceIndex = IngredientsList[i].IndexOf(" ");
                double quantity = double.Parse(IngredientsList[i].Substring(0, spaceIndex));

                switch (choice)
                {
                    case "1":
                        quantity /= 0.5;
                        break;
                    case "2":
                        quantity /= 2;
                        break;
                    case "3":
                        quantity /= 3;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                IngredientsList[i] = $"{quantity:F2} {IngredientsList[i].Substring(spaceIndex + 1)}";
            }
        }
    }
}
//****************************************end of file***********************************************//

