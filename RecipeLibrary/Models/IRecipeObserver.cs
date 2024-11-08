﻿namespace RecipeLibrary.Models
{
    // Интерфейс за наблюдател на рецепта
    // Използваме шаблона Observer, за да позволим на обектите (наблюдатели) 
    // да получават актуализации, когато състоянието на рецептата се променя.
    // Шаблонът Observer предоставя следните предимства:

    // 1. Разделяне на отговорности: Наблюдателите са отделени от самата рецепта, 
    //    което позволява по-добро управление на кода и улеснява добавянето на нови наблюдатели без 
    //    да се променя основният клас на рецептата.

    // 2. **Динамично регистриране и отписване**: Позволява наблюдателите да се регистрират и 
    //    отписват от събития по време на изпълнение, което предоставя гъвкавост при управлението на 
    //    уведомленията.

    // 3. **Автоматично известяване**: Когато рецептата се обновява или редактира, всички регистрирани 
    //    наблюдатели получават известие и могат да реагират адекватно, като например актуализиране на 
    //    интерфейса или изпращане на известия.
    public interface IRecipeObserver // Интерфейс за наблюдател на рецепта
    {
        void Update(Recipe recipe); // Метод за обновяване на рецепта
        void Edit(Recipe recipe); // Метод за редактиране на рецепта
    }
}
