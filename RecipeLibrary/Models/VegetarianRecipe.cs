namespace RecipeLibrary.Models
{
    public class VegetarianRecipe : IRecipeType // Клас за вегетариански рецепти
    {
        public string GetRecipeType()
        {
            return "Vegetarian";
        }
    }
}
