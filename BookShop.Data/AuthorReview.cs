using System;
using System.ComponentModel.DataAnnotations;
using BookShop.Data.Common;

namespace BookShop.Data
{
    /// <summary>
    /// Klasa przedstawiająca recenzje o autorze
    /// </summary>
    public class AuthorReview : Entity<int>
    {
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Wymagana jest ocena")]
        [Range(1, 5, ErrorMessage = "Ocena jest wymagana")]
        [Display(Name = "Ocena")]
        public int ReviewRate { get; set; }
        public int AuthorId { get; set; }
        public string UserId { get; set; }

        [Display(Name = "Recenzja")]
        [Required(ErrorMessage = "Napisz kilka słów od siebie")]
        [StringLength(500, ErrorMessage = "Maksymalnie 500 znaków")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual Author Author { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}