using System.Data.SQLite;
using System.Collections.Generic;

namespace RecipeLibrary.Models
{
    public class RecipeDatabase
    {
        private readonly string _connectionString;

        public RecipeDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }
        // Метод за инициализиране на базата данни, ако не съществува
        public void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(
                    "CREATE TABLE IF NOT EXISTS Recipes (Id INTEGER PRIMARY KEY AUTOINCREMENT, Title TEXT NOT NULL, Description TEXT NOT NULL, PrepTimeInMinutes INTEGER NOT NULL)",
                    connection
                );
                command.ExecuteNonQuery();
            }
        }

        // Метод за добавяне на рецепта
        public void AddRecipe(Recipe recipe)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("INSERT INTO Recipes (Title, Description, PrepTimeInMinutes) VALUES (@title, @description, @prepTime)", connection);
                command.Parameters.AddWithValue("@title", recipe.Title);
                command.Parameters.AddWithValue("@description", recipe.Description);
                command.Parameters.AddWithValue("@prepTime", recipe.PrepTimeInMinutes);
                command.ExecuteNonQuery();
            }
        }

        // Метод за четене на всички рецепти
        public List<Recipe> GetAllRecipes()
        {
            var recipes = new List<Recipe>();

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT * FROM Recipes", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        recipes.Add(new Recipe
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            PrepTimeInMinutes = reader.GetInt32(3)
                        });
                    }
                }
            }

            return recipes;
        }

        // Метод за четене на рецепта по ID
        public Recipe GetRecipeById(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT * FROM Recipes WHERE Id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Recipe
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            PrepTimeInMinutes = reader.GetInt32(3)
                        };
                    }
                }
            }

            return null;
        }

        // Метод за актуализиране на рецепта
        public void UpdateRecipe(Recipe recipe)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("UPDATE Recipes SET Title = @title, Description = @description, PrepTimeInMinutes = @prepTime WHERE Id = @id", connection);
                command.Parameters.AddWithValue("@title", recipe.Title);
                command.Parameters.AddWithValue("@description", recipe.Description);
                command.Parameters.AddWithValue("@prepTime", recipe.PrepTimeInMinutes);
                command.Parameters.AddWithValue("@id", recipe.Id);
                command.ExecuteNonQuery();
            }
        }

        // Метод за изтриване на рецепта
        public void DeleteRecipe(int id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("DELETE FROM Recipes WHERE Id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
