using Microsoft.AspNetCore.Mvc;
using RecipeLibrary.Models;

namespace RecipeLibrary.Controllers
{
    public class RecipeController : Controller
    {
        private readonly RecipeDatabase _db;
        private readonly RecipeNotifier _notifier;

        public RecipeController(RecipeDatabase db, RecipeNotifier notifier)
        {
            _db = db;
            _notifier = notifier;
        }

        // GET: RecipeController
        // Метод за показване на всички рецепти
        public IActionResult Index()
        {
            List<Recipe> recipes = _db.GetAllRecipes();
            return View(recipes);
        }
        // GET: RecipeController/Create
        // Метод за създаване на нова рецепта
        public IActionResult Create()
        {
            return View();
        }
        // POST: RecipeController/Create
        // Метод за добавяне на нова рецепта
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string recipeType, Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                // Използване на фабриката за създаване на типа рецепта
                var recipeCategory = RecipeFactory.CreateRecipeType(recipeType);
                recipe.Description = $"{recipeCategory.GetRecipeType()} - {recipe.Description}";

                // Добавяне на рецептата в базата данни
                _db.AddRecipe(recipe);

                // Изпращане на уведомление за добавяне на рецепта
                _notifier.Notify(recipe);

                return RedirectToAction("Index");
            }
            return View(recipe);
        }
        // GET: RecipeController/Details/
        // Метод за показване на детайли за рецепта
        public IActionResult Details(int id)
        {
            var recp = _db.GetRecipeById(id);
            return View(recp);
        }
        // GET: RecipeController/Edit/
        // Метод за редактиране на рецепта
        public IActionResult Edit(int id)
        {
            var recp = _db.GetRecipeById(id);
            if (recp == null)
            {
                return NotFound();
            }
            return View(recp);
        }

        // POST: RecipeController/Edit/
        // Метод за запазване на редактираната рецепта
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Recipe recipe)
        {
            _db.UpdateRecipe(recipe);
            _notifier.Edit(recipe);
            return RedirectToAction("Index");
        }

        // GET: RecipeController/Delete/
        // Метод за показване на формата за потвърждение на изтриване
        public IActionResult Delete(int id)
        {
            var recp = _db.GetRecipeById(id);
            if (recp == null)
            {
                return NotFound();
            }
            return View(recp);
        }

        // POST: RecipeController/Delete/
        // Метод за изтриване на рецепта
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            _db.DeleteRecipe(id);
            return RedirectToAction("Index");
        }
    }
}
