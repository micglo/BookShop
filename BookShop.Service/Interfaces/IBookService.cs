using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Models.QueryString;
using BookShop.Models.ViewModels;
using BookShop.Models.ViewModels.Books;

namespace BookShop.Service.Interfaces
{
    public interface IBookService : IGenericService<Book>
    {
        Task<IEnumerable<BookIndexViewModel>> GetAll();

        Task<BooksForMainCategoryViewModel> GetBooksForMainCategory(string mainCategoryName);

        Task<BooksForSubMainCategoryViewModel> GetBooksForSubMainCategory(string mainCategoryName,
            string subMainCategoryName, int page, int itemsPerPage, string sortOrder);

        Task<BooksForBookCategoryViewModel> GetBooksForBookCategory(string mainCategoryName, string subMainCategoryName,
            string bookCategoryName, int page, int itemsPerPage, string sortOrder);

        Task<BookViewModel> GetById(int id);

        Task<Book> GetBookById(int bookId);

        Task<BooksBySearchStringViewModel> GetBooksBySearchString(QueryStringSearch queryModel);

        Task<BookPostViewModel> GetBookCreateViewModel();

        Task<BookPostResponseViewModel> Create(BookPostViewModel book);

        Task<BookEditViewModel> GetBookEditViewModel(int id);

        Task<BookPostResponseViewModel> Edit(BookEditViewModel book);

        Task<IEnumerable<BookCategoriesSelectList>> GetBookCategories(string[] subMainCategoryIdList);

        Task<bool> Exists(int id);

        Task<bool> BadRequest(string mainCategoryName, string subMainCategoryName = null, string bookCategoryName = null);

        Task<InfoViewModel> Delete(int id);

        Task SetBestseller(int id);

        Task RemoveBestseller(int id);
    }
}