﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieRateCRUD.Models
{
    public class Movie
    { 
        // идентификатор
        public int Id { get; set; }

        // название фильма
        [Required(ErrorMessage = "The field has to be set.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The string length have to be from 3 to 50 symbols")]
        public string? Title { get; set; }

        // режиссер
        [Required(ErrorMessage = "The field has to be set.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The string length have to be from 3 to 50 symbols")]
        public string? Director { get; set; }

        // жанр
        [Required(ErrorMessage = "The field has to be set.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The string length have to be from 3 to 50 symbols")]
        public string? Genre { get; set; }

        // год выпуска
        [Required(ErrorMessage = "Please enter the year of movie release.")]
        [YearRange(1900, ErrorMessage = "Please enter a valid year")]
        [Display(Name = "Release")]
        public int? Release { get; set; }

        // постер
        public string? Poster { get; set; }

        // краткое описание
        [Required(ErrorMessage = "The field has to be set.")]
        [StringLength(300, MinimumLength = 3, ErrorMessage = "The string length have to be from 3 to 300 symbols")]
        public string? Description { get; set; }

    }


    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class YearRangeAttribute : RangeAttribute
    {
        public YearRangeAttribute(int minimum) : base(minimum, DateTime.Now.Year)
        {
        }
    }

}