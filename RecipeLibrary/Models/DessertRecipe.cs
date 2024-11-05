namespace RecipeLibrary.Models
{
    public class DessertRecipe : IRecipeType
    {
        public string GetRecipeType() // Метод за връщане на типа на рецептата
        {
            return "Dessert";
        }
    }
}
