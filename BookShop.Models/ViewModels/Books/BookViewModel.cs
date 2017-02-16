using System;
using System.Collections.Generic;
using BookShop.Data;

namespace BookShop.Models.ViewModels.Books
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string TitleForDisplay { get; set; }
        public DateTime PublishDate { get; set; }
        public string ISBN { get; set; }
        public int? PageSize { get; set; }
        public string BookSize { get; set; }
        public string Image { get; set; }
        public bool? Bestseller { get; set; }
        public string Language { get; set; }
        public string Cover { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        public Publishing Publishing { get; set; }
        public ICollection<Author> Author { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
        public ICollection<SubMainCategory> SubMainCategories { get; set; }
        public ICollection<Data.BookReview> BookReviews { get; set; }
    }
}