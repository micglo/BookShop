using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Models.ViewModels.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "Podaj email")]
        [EmailAddress(ErrorMessage = "Niepoprawny adres email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string ReturnUrl { get; set; }

        public string LoginProvider { get; set; }

        public List<string> Errors { get; set; } = new List<string>();
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }

    public class VerifyCodeViewModel
    {
        [Required(ErrorMessage = "Provider jest wymagany")]
        public string Provider { get; set; }

        [Required(ErrorMessage = "Kod jest wymagany")]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }

        public List<string> Errors { get; set; } = new List<string>();
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Podaj email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Niepoprawny adres email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Podaj hasło")]
        [StringLength(100, ErrorMessage = "{0} musi mieć conajmniej {2} znaków", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj?")]
        public bool RememberMe { get; set; }

        public List<string> Errors { get; set; } = new List<string>();
        public string ReturnUrl { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Podaj email")]
        [EmailAddress(ErrorMessage = "Niepoprawny adres email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Podaj hasło")]
        [StringLength(100, ErrorMessage = "{0} musi mieć conajmniej {2} znaków", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Powtórz hasło")]
        [StringLength(100, ErrorMessage = "{0} musi mieć conajmniej {2} znaków", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Hasła nie pasują")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Podaj email")]
        [EmailAddress(ErrorMessage = "Niepoprawny adres email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Podaj hasło")]
        [StringLength(100, ErrorMessage = "{0} musi mieć conajmniej {2} znaków", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Powtórz hasło")]
        [StringLength(100, ErrorMessage = "{0} musi mieć conajmniej {2} znaków", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Hasła nie pasują")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
        public string Error { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Podaj email")]
        [EmailAddress(ErrorMessage = "Niepoprawny adres email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }

    public class ResendEmailConfirmationViewModel
    {
        [Required(ErrorMessage = "Podaj email")]
        [EmailAddress(ErrorMessage = "Niepoprawny adres email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Podaj hasło")]
        [StringLength(100, ErrorMessage = "{0} musi mieć conajmniej {2} znaków", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
    }
}