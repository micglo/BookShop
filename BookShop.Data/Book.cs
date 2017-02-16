using System;
using System.Collections.Generic;
using BookShop.Data.Common;

namespace BookShop.Data
{
    /// <summary>
    /// Klasa przedstawiająca książkę
    /// </summary>
    public class Book : Entity<int>
    {
        /// <summary>
        /// Używane w URL
        /// </summary>
        public string Title { get; set; }
        public string TitleForDisplay { get; set; }
        public int PublishingId { get; set; }
        public DateTime PublishDate { get; set; }
        public string ISBN { get; set; }
        public int? PageSize { get; set; }
        public string BookSize { get; set; }       
        public string Image { get; set; }
        public bool? Bestseller { get; set; }
        public Language Language { get; set; }

        /// <summary>
        /// Książka typu ebook czy audiobook nie ma okładki
        /// </summary>
        public Cover Cover { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public virtual Publishing Publishing { get; set; }
        public virtual ICollection<Author> Author { get; set; }
        public virtual ICollection<BookCategory> BookCategories { get; set; }
        public virtual ICollection<SubMainCategory> SubMainCategories { get; set; }
        public virtual ICollection<BookReview> BookReviews { get; set; }       
        public virtual ICollection<TransactionBookQuantity> TransactionBookQuantitys { get; set; }       
    }
}