using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookShop.Data.Common;

namespace BookShop.Data
{
    //Klasa reprezentująca wydawnictwo
    public class Publishing : Entity<int>
    {
        /// <summary>
        /// Używane w URL
        /// </summary>
        [Required(ErrorMessage = "Nazwa wydawnictwa jest wymagana")]
        [StringLength(100, ErrorMessage = "Maksymalnie 100 znaków")]
        [DataType(DataType.Text)]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nazwa wydawnictwa jest wymagana")]
        [StringLength(100, ErrorMessage = "Maksymalnie 100 znaków")]
        [DataType(DataType.Text)]
        [Display(Name = "Nazwa do wyświetlenia")]
        public string NameForDisplay { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Link do zdjęcia")]
        public string Image { get; set; }

        [Display(Name = "Opis")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<PublishingReview> PublishingReviews { get; set; }
    }
}