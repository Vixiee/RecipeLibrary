using System.Collections.Generic;
namespace RecipeLibrary.Models
{
    public class RecipeNotifier // Клас за известяване на наблюдатели за рецепти
    {
        // List of observers
        private readonly List<IRecipeObserver> _observers = new List<IRecipeObserver>();
        // Subscribe method
        public void Subscribe(IRecipeObserver observer) => _observers.Add(observer);
        // Unsubscribe method
        public void Unsubscribe(IRecipeObserver observer) => _observers.Remove(observer);

        // Метод за известяване на всички наблюдатели за добавянето на рецепта
        public void Notify(Recipe recipe)
        {
            foreach (var observer in _observers)
            {
                observer.Update(recipe);
            }
        }

        // Метод за известяване на всички наблюдатели за редактирането на рецепта
        public void Edit(Recipe recipe)
        {
            foreach (var observer in _observers)
            {
                observer.Edit(recipe);
            }
        }
    }
}
