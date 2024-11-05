using Microsoft.Extensions.Configuration; // За конфигурация от appsettings.json
using RecipeLibrary.Models;
using System.Data.SQLite;

var builder = WebApplication.CreateBuilder(args);

// Извличане на връзката към базата данни от appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Инициализиране на RecipeDatabase и създаване на таблицата, ако не съществува
var recipeDatabase = new RecipeDatabase(connectionString);
recipeDatabase.InitializeDatabase(); // Създава таблицата за рецепти

// Регистриране на RecipeDatabase като Singleton услуга
// Използваме Singleton шаблона, за да гарантираме, че приложението използва само една инстанция на RecipeDatabase.
// Това е полезно, защото:
// 1. Осигурява централизирано управление на ресурсите и подобрява производителността, 
//    като избягва многократното създаване и унищожаване на обекти.

// 2. Позволява на RecipeDatabase да споделя състояние (например текущи настройки и връзка с базата данни) 
//    между различни части на приложението, което е особено полезно за приложения с множество 
//    контролери и услуги, които взаимодействат с базата данни.
builder.Services.AddSingleton(recipeDatabase);

// Добавяне на услугите към контейнера
builder.Services.AddControllersWithViews();

var notifier = new RecipeNotifier();
notifier.Subscribe(new RecipeUserObserver("User1"));

// Регистриране на RecipeNotifier като Singleton услуга
// Използваме Singleton шаблона за RecipeNotifier, за да осигурим, че всички наблюдатели 
// получават уведомления от същата инстанция на RecipeNotifier. 
// Това позволява на всички компоненти на приложението да реагират на промените 
// в рецептите по последователен начин и спестява ресурси, 
// като не създава нови инстанции за всеки нов потребител.

builder.Services.AddSingleton(notifier);

var app = builder.Build();

// Конфигурация на HTTP заявките
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
