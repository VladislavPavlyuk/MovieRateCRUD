using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieRateCRUD.Models
{
    public class Movie
    { 
        // идентификатор
        public int Id { get; set; }

        // название фильма
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string? Title { get; set; }

        // режиссер
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string? Director { get; set; }

        // жанр
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string? Genre { get; set; }

        // год выпуска
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [Display(Name = "Год")]
        public string? Release { get; set; }

        // постер
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [Display(Name = "path to image")]
        public string? Poster { get; set; }

        // краткое описание
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [StringLength(300, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 300 символов")]
        public string? Description { get; set; }
    }
}