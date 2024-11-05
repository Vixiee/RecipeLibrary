namespace RecipeLibrary.Models
{
    public static class RecipeFactory // Фабрика за създаване на рецепти
    {
        public static IRecipeType CreateRecipeType(string type) // Метод за създаване на тип на рецепта

        // Използваме фабричния шаблон, за да отделим логиката за създаване на обекти от тяхната реализация.

        // Фабричният шаблон осигурява следните предимства:

        // 1. **Инкапсулация на логиката за създаване**: Позволява на клиента да не знае как точно се създават конкретните 
        //    класове за рецепти (например VegetarianRecipe, VeganRecipe, DessertRecipe), а само да посочи типа, 
        //    който иска. Това намалява зависимостите между класовете и улеснява управлението на кодовата база.

        // 2. **Лесно добавяне на нови типове**: Когато искаме да добавим нов тип рецепта, 
        //    просто добавяме нов случай в метода CreateRecipeType, без да променяме клиентския код.

        // 3. **Стандартизиране на създаването на обекти**: Предоставя стандартен начин за създаване на различни 
        //    типове рецепти, което прави кода по-четим и подреден.
        {
            switch (type)
            {
                case "Vegetarian":
                    return new VegetarianRecipe();
                case "Vegan":
                    return new VeganRecipe();
                case "Dessert":
                    return new DessertRecipe();
                default:
                     throw new ArgumentException("Invalid recipe type!");
            }
        }
    }
}
