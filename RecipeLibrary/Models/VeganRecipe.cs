namespace RecipeLibrary.Models
{
    public class VeganRecipe : IRecipeType // Клас за вегански рецепти
    {
        // Properties
        public string GetRecipeType()
        {
            return "Vegan";
        }
    }
}
