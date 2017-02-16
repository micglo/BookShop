using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookShop.Data
{
    /// <summary>
    /// Klasa przedstawiająca użytkownika
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public bool IsCompany { get; set; }
        public string CompanyName { get; set; }
        public string Regon { get; set; }
        public string Nip { get; set; }

        public virtual ICollection<BookReview> BookReviews { get; set; }
        public virtual ICollection<AuthorReview> AuthorReviews { get; set; }
        public virtual ICollection<PublishingReview> PublishingReviews { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}