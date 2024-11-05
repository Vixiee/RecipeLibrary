using System.ComponentModel.DataAnnotations;

namespace RecipeLibrary.Models
{
    public class Recipe
    {
        // Идентификатор на рецептата
        public int Id { get; set; }

        // Заглавие на рецептата - задължително поле с ограничение на дължината
        [Required(ErrorMessage = "Заглавието на рецептата е задължително.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Заглавието трябва да бъде между 5 и 100 символа.")]
        public string Title { get; set; }

        // Описание на рецептата - задължително поле с ограничение на дължината
        [Required(ErrorMessage = "Описанието на рецептата е задължително.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Описанието трябва да бъде между 10 и 500 символа.")]
        public string Description { get; set; }

        // Време за приготвяне в минути - задължително поле с валиден диапазон
        [Required(ErrorMessage = "Времето за приготвяне е задължително.")]
        [Range(1, 1440, ErrorMessage = "Въведете валидно време за приготвяне между 1 и 1440 минути.")]
        public int PrepTimeInMinutes { get; set; }
    }
}


