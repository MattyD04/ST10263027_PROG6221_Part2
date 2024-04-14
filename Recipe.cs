using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// utilised Claude AI for debugging and to mainly fix a debugging target error
///
///
namespace RecipeManagerPOE
{
    internal class Recipe
    {
        public string ingredients { get; set; }
        public string RecipeName { get; set; } //name of the recipe
        public int NumIng { get; set; } //variable to store the amount of ingredients will be needed for the recipe
        public string InName { get; set; } //the name of the ingredient
        public double InQuant { get; set; } //variable to store quantity of ingredients used
        public string unit { get; set; } //unit of measurement used for the ingredients
        public List<string> StepsLists { get; set; } = new List<string>(); //this list will be used to store the steps for the recipe
        public List<string> IngredientsList { get; set; } = new List<string>(); //array list to store the ingredients

        public void AddIngredient()
        {

        }
        //****************************************************************************//
        public void AddSteps()
        {

        }
        //****************************************************************************//
        public static void ResetRecipe()
        {

        }
        //****************************************************************************//
        public static void DisplayRecipe()
        {

        }
        //****************************************************************************//
        public static void ScaleRecipe()
        {

        }
        //****************************************************************************//
    }
}
//****************************************end of file***********************************************//

