using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


/// utilised Claude AI for debugging and to mainly fix a debugging target error
///
///
namespace RecipeManagerPOE
{
    internal class Recipe
    {
        public string ingredient { get; set; }
        public int NumIng { get; set; } //variable to store the amount of ingredients will be needed for the recipe
        public string IngName { get; set; } //the name of the ingredient
        public double IngQuant { get; set; } //variable to store quantity of ingredients used
        public string unit { get; set; } //unit of measurement used for the ingredients
        public List<string> StepsLists { get; set; } = new List<string>(); //this list will be used to store the steps for the recipe
        public List<string> IngredientsList { get; set; } = new List<string>(); //array list to store the ingredients

        public void AddIngredient()
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
                ingredient = $"{IngQuant} {unit} of {IngName}";
                IngredientsList.Add(ingredient);
            }
        }
        //****************************************************************************//
        public void AddSteps()
        {

        }
        //****************************************************************************//
        public void ResetRecipe()
        {
            IngredientsList.Clear();
            StepsLists.Clear();
        }
        //****************************************************************************//
        public void DisplayRecipe()
        {

        }
        //****************************************************************************//
        public void ScaleRecipe()
        {

        }
        //****************************************************************************//
    }
}
//****************************************end of file***********************************************//

