namespace RecipeLibrary.Models
{
    public class RecipeUserObserver : IRecipeObserver // Наблюдател на рецепта за потребител
    {
        private readonly string _userName;

        public RecipeUserObserver(string userName)
        {
            _userName = userName;
        }

        //  Метод за известяване на потребителя за добавянето на рецепта
        public void Update(Recipe recipe)
        {
            Console.WriteLine($"User {_userName} has been notified of a new recipe: {recipe.Title}");
        }

        //  Метод за известяване на потребителя за редактирането на рецепта
        public void Edit(Recipe recipe)
        {
            Console.WriteLine($"User {_userName} has been notified of an updated recipe: {recipe.Title}");
        }
    }
}
