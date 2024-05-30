using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

/*
 * References: 
 * https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/
 * https://www.geeksforgeeks.org/console-readkey-method-in-c-sharp/ 
 * https://www.geeksforgeeks.org/lambda-expressions-in-c-sharp/
 * https://www.gosh.nhs.uk/conditions-and-treatments/general-health-advice-children/eat-smart/food-science/food-group-fun/
 */
// utilised Claude AI for debugging and to mainly fix a debugging target error
namespace RecipeManagerPOE
{
    internal class Recipe
    {
        public delegate void CalorieNotificationHandler(double totalCalories); //delegate for a notification that tells a user a recipe has reached 300 calories
        public string ingredient { get; set; } // Variable to create string representation of the ingredient
        public int NumIng { get; set; } // Variable to store the amount of ingredients needed for the recipe
        public string IngName { get; set; } // The name of the ingredient
        public double IngQuant { get; set; } // Variable to store the quantity of ingredients used
        public string unit { get; set; } // Unit of measurement used for the ingredients
        public int NumStep { get; set; } // Variable for the number of recipe steps
        public string Step { get; set; } // Variable for the step in the recipe
        public string RecipeName { get; set; } // Property to store the name of the recipe
        public List<string> StepsLists { get; set; } = new List<string>(); // List to store the steps for the recipe
        public List<string> IngredientsList { get; set; } = new List<string>(); // List to store the ingredients
        public List<Recipe> RecipeList { get; set; } = new List<Recipe>(); // List to store the recipes

        public void SetRecipeName() //method to allow the user to enter the recipe name
        {
            Console.WriteLine("Please enter the recipe name:");
            RecipeName = Console.ReadLine().Trim();
        }
        //****************************************************************************//
        public void AddIngredient() //adds the ingredients to the ingredient list
        {
            Console.WriteLine("Please enter the number of ingredients you wish to include in this recipe!");
            try
            {
                NumIng = int.Parse(Console.ReadLine()); // Parse the user input from string to int

                for (int i = 0; i < NumIng; i++)
                {
                    Console.WriteLine("Enter the ingredient name: ");
                    IngName = Console.ReadLine().Trim();

                    Console.WriteLine("Enter the quantity of the ingredient: ");
                    IngQuant = double.Parse(Console.ReadLine().Trim()); // Parse the user input from string to double

                    Console.WriteLine("Enter the unit of measurement: ");
                    unit = Console.ReadLine().Trim();

                    string foodGroup = GetFoodGroup(); // Calls the GetFoodGroup() method to get the food group for the ingredient

                    Console.WriteLine("Enter the number of calories: "); // Prompt the user to enter the number of calories
                    double calories = double.Parse(Console.ReadLine());

                    // Create a string representation of the ingredient with all the relevant information
                    ingredient = $"{IngQuant} {unit} of {IngName} ({foodGroup}, {calories} calories)";
                    IngredientsList.Add(ingredient);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please try again");
            }
        }
        //****************************************************************************//
        public string GetFoodGroup() //method to allow the user to choose the food group of an ingredient
        {
            Console.WriteLine();
            Console.WriteLine("Select the food group for this ingredient:"); // Prompt the user to select the food group
            Console.WriteLine("1. Protein");
            Console.WriteLine("2. Carbohydrates");
            Console.WriteLine("3. Dairy");
            Console.WriteLine("4. Fruits");
            Console.WriteLine("5. Vegetables");
            int foodGroupChoice = int.Parse(Console.ReadLine()); // Get the user's choice for the food group
            string foodGroup = "";

            switch (foodGroupChoice) // user selection of the food group
            {
                case 1:
                    foodGroup = "Protein";
                    break;
                case 2:
                    foodGroup = "Carbohydrates";
                    break;
                case 3:
                    foodGroup = "Dairy";
                    break;
                case 4:
                    foodGroup = "Fruits";
                    break;
                case 5:
                    foodGroup = "Vegetables";
                    break;
            }

            return foodGroup; // Return the selected food group
        }
        //****************************************************************************//
        public double CalculateTotalCalories() //method to calculate the total calories of a recipe
        {
            double totalCalories = 0;
            foreach (string ingredient in IngredientsList)
            {
                int startIndex = ingredient.IndexOf("(") + 1;
                int endIndex = ingredient.IndexOf(" calories)");
                double calories = double.Parse(ingredient.Substring(startIndex, endIndex - startIndex));
                totalCalories += calories;
            }
            return totalCalories;
        }
        //****************************************************************************//
        public void AddSteps() //method to add the steps to the steps list (corrected by chatgpt)
        {
            Console.WriteLine("Please enter the number of steps for the recipe! ");
            NumStep = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the recipe steps: ");
            for (int i = 0; i < NumStep; i++)
            {
                Step = Console.ReadLine().Trim();
                StepsLists.Add(Step);
            }

            // Add the recipe to the RecipeList
            Recipe newRecipe = new Recipe
            {
                RecipeName = this.RecipeName,
                IngredientsList = new List<string>(this.IngredientsList),
                StepsLists = new List<string>(this.StepsLists)
            };
            RecipeList.Add(newRecipe);

            double totalCalories = CalculateTotalCalories(); // Calculates and display total calories
            Console.WriteLine($"Total Calories for {RecipeName}: {totalCalories}");

            // Clear the IngredientsList and StepsLists for the next recipe
            IngredientsList.Clear();
            StepsLists.Clear();

            Console.WriteLine("Recipe saved successfully!\n");
        }
        //****************************************************************************//
        public void ClearRecipe() //debugged and corrected by Claude AI
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
        public void DisplayRecipes() //this method displays the recipes with the recipe names, ingredients and steps (debugged and corrected by Claude AI)
        {
            if (RecipeList.Count == 0)
            {
                Console.WriteLine("No recipes saved yet.");
            }
            else
            {
                //lambda expression to sort the recipes into alphabetical order
                RecipeList.Sort((x, y) => string.Compare(x.RecipeName, y.RecipeName, StringComparison.OrdinalIgnoreCase));
                for (int i = 0; i < RecipeList.Count; i++)
                {
                    Console.WriteLine($"Recipe {i + 1}: {RecipeList[i].RecipeName}");
                    Console.WriteLine("Ingredients:");
                    foreach (string ingredient in RecipeList[i].IngredientsList)
                    {
                        Console.WriteLine(ingredient);
                    }
                    Console.WriteLine("Steps:");
                    for (int j = 0; j < RecipeList[i].StepsLists.Count; j++)
                    {
                        Console.WriteLine($"{j + 1}. {RecipeList[i].StepsLists[j]}");
                    }
                    Console.WriteLine();
                }
            }
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
        public void ResetScale() //this method resets the scale of the recipe (debugged and corrected by Claude AI)
        {
            Console.WriteLine("Resetting recipe to original values.");

            // Create a new empty list to store the original ingredient values
            List<string> originalIngredients = new List<string>();

            // Iterate through the IngredientsList
            for (int i = 0; i < IngredientsList.Count; i++)
            {
                int spaceIndex = IngredientsList[i].IndexOf(" ");

                string originalQuantity = IngredientsList[i].Substring(0, spaceIndex);
                string originalUnit = IngredientsList[i].Substring(spaceIndex + 1);

                string originalIngredient = $"{IngQuant} {unit} of {IngName}";
                originalIngredients.Add(originalIngredient);
            }

            IngredientsList = originalIngredients;

            Console.WriteLine("Recipe has been reset to original values.");
        }
    }
}
//****************************************end of file***********************************************//

