using System.ComponentModel.DataAnnotations;

namespace BookShop.Models.ViewModels.ShoppingCart
{
    public class OtherDeliveryAddressViewModel
    {
        [Required(ErrorMessage = "Podaj imie")]
        [StringLength(50, ErrorMessage = "Maksymalnie 50 znaków")]
        [DataType(DataType.Text)]
        [Display(Name = "Imie")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Podaj nazwisko")]
        [StringLength(50, ErrorMessage = "Maksymalnie 50 znaków")]
        [DataType(DataType.Text)]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [StringLength(11, ErrorMessage = "Numer telefonu musi miec równo 11 znaków", MinimumLength = 11)]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Podaj nazwe ulicy")]
        [StringLength(50, ErrorMessage = "Maksymalnie 50 znaków")]
        [DataType(DataType.Text)]
        [Display(Name = "Ulica wraz z numerem")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Podaj nazwe miejscowości")]
        [StringLength(50, ErrorMessage = "Maksymalnie 50 znaków")]
        [DataType(DataType.Text)]
        [Display(Name = "Miejscowość")]
        public string City { get; set; }

        [Required(ErrorMessage = "Podaj kod pocztowy")]
        [StringLength(6, ErrorMessage = "Podaj kod pocztowy w formacie xx-xxx", MinimumLength = 6)]
        [RegularExpression("\\d{2}-\\d{3}", ErrorMessage = "Podaj kod pocztowy w formacie xx-xxx")]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Kod pocztowy")]
        public string PostCode { get; set; }

        public bool OtherDeliveryAddress { get; set; }
    }
}