using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookShop.Data.Common;

namespace BookShop.Data
{
    /// <summary>
    /// Klasa przedstawiająca autora
    /// </summary>
    public class Author : Entity<int>
    {
        [Required(ErrorMessage = "Imie autora jest wymagane")]
        [StringLength(50, ErrorMessage = "Maksymalnie 50 znaków")]
        [DataType(DataType.Text)]
        [Display(Name = "Imie")]
        public string FirstName { get; set; }

        /// <summary>
        /// Używane w URL
        /// </summary>
        [Required(ErrorMessage = "Nazwisko autora jest wymagane")]
        [StringLength(50, ErrorMessage = "Maksymalnie 50 znaków")]
        [DataType(DataType.Text)]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        /// <summary>
        /// Używane do wyświetlania
        /// </summary>
        [Required(ErrorMessage = "Nazwisko autora jest wymagane")]
        [StringLength(50, ErrorMessage = "Maksymalnie 50 znaków")]
        [DataType(DataType.Text)]
        [Display(Name = "Nazwisko do wyświetlenia")]
        public string LastNameForDisplay { get; set; }

        [Display(Name = "Opis")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<AuthorReview> AuthorReviews { get; set; }
    }
}