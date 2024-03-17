using System.ComponentModel;

namespace MovieRateCRUD.Models
{
    public class Movie
    { 
        // идентификатор
        public int Id { get; set; }

        // название фильма
        public string? Title { get; set; }

        // режиссер
        public string? Director { get; set; }

        // жанр
        public string? Genre { get; set; }

        // год выпуска
        public string? Release { get; set; }

        // постер
        public string? Poster { get; set; }

        // краткое описание
        public string? Description { get; set; }
    }
}