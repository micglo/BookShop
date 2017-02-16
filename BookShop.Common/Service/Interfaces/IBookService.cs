using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Models.ViewModels;

namespace BookShop.Common.Service.Interfaces
{
    public interface IBookService : IGenericService<Book>
    {
        Task<BooksForMainCategoryViewModel> GetBooksForMainCategory(string mainCategoryName);

        Task<BooksForSubMainCategoryViewModel> GetBooksForSubMainCategory(string mainCategoryName,
            string subMainCategoryName);

        Task<BooksForBookCategoryViewModel> GetBooksForBookCategory(int page, int itemsPerPage, string mainCategoryName,
            string subMainCategoryName, string bookCategoryName, string sortOrder = null);

        Task<Book> GetFirstBookById(int bookId);

        Task<BooksBySearchStringViewModel> GetBooksBySearchString(int page, int itemsPerPage, string searchString, string sortOrder = null);
    }
}