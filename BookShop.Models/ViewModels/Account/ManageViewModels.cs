using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace BookShop.Models.ViewModels.Account
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel : InfoViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
        public bool ShowRemoveButton { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required(ErrorMessage = "Podaj hasło")]
        [StringLength(100, ErrorMessage = "{0} musi mieć conajmniej {2} znaków", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Powtórz hasło")]
        [StringLength(100, ErrorMessage = "{0} musi mieć conajmniej {2} znaków", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Compare("NewPassword", ErrorMessage = "Hasła nie pasują")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Podaj aktualne hasło")]
        [StringLength(100, ErrorMessage = "{0} musi mieć conajmniej {2} znaków", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Aktualne hasło")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Podaj nowe hasło")]
        [StringLength(100, ErrorMessage = "{0} musi mieć conajmniej {2} znaków", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nowe hasło")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Powtórz nowe hasło")]
        [StringLength(100, ErrorMessage = "{0} musi mieć conajmniej {2} znaków", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź nowe hasło")]
        [Compare("NewPassword", ErrorMessage = "Hasła nie pasują")]
        public string ConfirmPassword { get; set; }
    }

    public class MyReviewsViewModel
    {
        public IEnumerable<Data.AuthorReview> MyAuthorReviews { get; set; }
        public IEnumerable<Data.BookReview> MyBookReviews { get; set; }
        public IEnumerable<Data.PublishingReview> MyPublishingReviews { get; set; }
    }

    public class UserDataPostViewModel
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

        [Required]
        [Display(Name = "Firma?")]
        public bool IsCompany { get; set; }

        public string Email { get; set; }
    }

    public class UserCompanyDataPostViewModel
    {
        [Required(ErrorMessage = "Podaj nazwę firmy")]
        [Display(Name = "Nazwa firmy"), StringLength(50, ErrorMessage = "Maksymalnie 50 znaków")]
        [DataType(DataType.Text)]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Podaj REGON")]
        [Display(Name = "REGON"), StringLength(9, ErrorMessage = "REGON musi składać się z 9 znaków", MinimumLength = 9)]
        [DataType(DataType.Text)]
        public string Regon { get; set; }

        [Required(ErrorMessage = "Podaj NIP")]
        [Display(Name = "NIP"), StringLength(10, ErrorMessage = "NIP musi składać się z 10 znaków", MinimumLength = 10)]
        [DataType(DataType.Text)]
        public string Nip { get; set; }
    }
}