using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BookShop.Models.ViewModels.Books
{
    /// <summary>
    /// Model dla akcji Create książki
    /// </summary>
    public class BookPostViewModel
    {
        [Required(ErrorMessage = "Tytuł książki jest wymagany")]
        [StringLength(100, ErrorMessage = "Maksymalnie 100 znaków")]
        [DataType(DataType.Text)]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Tytuł książki jest wymagany")]
        [StringLength(100, ErrorMessage = "Maksymalnie 100 znaków")]
        [DataType(DataType.Text)]
        [Display(Name = "Tytuł do wyświetlenia")]
        public string TitleForDisplay { get; set; }

        [Required(ErrorMessage = "Data publikacji książki jest wymagana")]
        [DataType(DataType.Text)]
        [Display(Name = "Data publikacji")]
        public string PublishDate { get; set; }

        [Required(ErrorMessage = "ISBN książki jest wymagany")]
        [StringLength(13, ErrorMessage = "Maksymalnie 13 znaków")]
        [DataType(DataType.Text)]
        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Display(Name = "Ilość stron")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Wartość nie może być mniejsza od zera")]
        public int? PageSize { get; set; }

        [Display(Name = "Format książki")]
        [DataType(DataType.Text)]
        [StringLength(20, ErrorMessage = "Maksymalnie 20 znaków")]
        public string BookSize { get; set; }

        [Display(Name = "Link do zdjęcia")]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [Display(Name = "Bestseller?")]
        public bool? Bestseller { get; set; }

        [Required(ErrorMessage = "Cena książki jest wymagana")]
        [Display(Name = "Cena")]
        [DataType(DataType.Currency)]
        public string Price { get; set; }

        [Required(ErrorMessage = "Ilość egzemplarzy jest wymagane")]
        [Display(Name = "Ilość egzemplarzy")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Wartość nie może być mniejsza od zera")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Opis książki jest wymagany")]
        [Display(Name = "Opis")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Język książki jest wymagany")]
        [Display(Name = "Język książki")]
        public string Language { get; set; }

        [Display(Name = "Rodzaj okładki")]
        public string Cover { get; set; }

        [Required(ErrorMessage = "Wydawnictwo jest wymagane")]
        [Display(Name = "Wydawnictwo")]
        public int PublishingId { get; set; }

        [Required(ErrorMessage = "Conajmniej jeden autor jest wymagany")]
        [Display(Name = "Autorzy")]
        public List<int> Authors { get; set; }

        [Required(ErrorMessage = "Conajmniej jedna podkategoria jest wymagana")]
        [Display(Name = "Kategorie")]
        public List<int> SubMainCategoryies { get; set; }

        [Display(Name = "Podkategorie dla kategorii")]
        public List<int> BookCategories { get; set; }

        
       
        public IEnumerable<SelectListItem> LanguagesSelectList { get; set; }
        public IEnumerable<SelectListItem> CoversSelectList { get; set; }
        public IEnumerable<SelectListItem> PublishingSelectList { get; set; }
        public IEnumerable<SelectListItem> AuthorSelectList { get; set; }
        public IList<SelectListItem> SubMainCategorySelectList { get; set; }
        public IEnumerable<SelectListItem> BookCategorySelectList { get; set; }
    }
}