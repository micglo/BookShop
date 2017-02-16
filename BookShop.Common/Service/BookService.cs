using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Common.Repository.Interfaces;
using BookShop.Common.Service.Interfaces;
using BookShop.Data;
using BookShop.Models.ViewModels;
using PagedList;

namespace BookShop.Common.Service
{
    public class BookService : GenericService<Book>, IBookService
    {
        public BookService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override async Task<IEnumerable<Book>> GetAllAsync()
            => await UnitOfWork.BookRepository.GetAllAsync(q => q.OrderBy(b => b.Title));

        public override async Task<Book> GetByIdAsync(object id) => await UnitOfWork.BookRepository.FindAsync(id);

        public override async Task AddAsync(Book model)
        {
            UnitOfWork.BookRepository.Add(model);
            await UnitOfWork.SaveChangesAsync();
        }

        public override async Task UpdateAsync(Book model)
        {
            UnitOfWork.BookRepository.Update(model);
            await UnitOfWork.SaveChangesAsync();
        }

        public override async Task DeleteAsync(long id)
        {
            var book = await GetByIdAsync(id);
            UnitOfWork.BookRepository.Remove(book);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<BooksForMainCategoryViewModel> GetBooksForMainCategory(string mainCategoryName)
        {
            var topFiveBooksForEachSubMainCategory = new List<Book>();

            var currentMainCategory = await GetCurrentMainCategory(mainCategoryName);

            var subMainCategoriesWithBooks =
                await
                    UnitOfWork.SubMainCategoryRepository.FindAllAsync(
                        s => s.MainCategory.Name.Equals(mainCategoryName) && s.Books.Any());
            var subMainCategoriesWithBooksList = subMainCategoriesWithBooks.ToList();

            foreach (var subMainCategory in subMainCategoriesWithBooksList)
            {
                var books =
                    await
                        UnitOfWork.BookRepository.FindAllAsync(
                            b => b.SubMainCategories.Any(s => s.Name.Equals(subMainCategory.Name)) && b.Bestseller.Value,
                            null, null, 5);
                topFiveBooksForEachSubMainCategory.AddRange(books);
            }

            return new BooksForMainCategoryViewModel
            {
                SubMainCategories = subMainCategoriesWithBooksList,
                TopFiveBooksForEachSubMainCategory = topFiveBooksForEachSubMainCategory,
                CurrentMainCategory = currentMainCategory
            };
        }

        public async Task<BooksForSubMainCategoryViewModel> GetBooksForSubMainCategory(string mainCategoryName, string subMainCategoryName)
        {
            var currentMainCategory = await GetCurrentMainCategory(mainCategoryName);
            var currentSubMainCategory = await GetCurrentSubMainCategory(mainCategoryName, subMainCategoryName);

            if (currentSubMainCategory.BookCategories.Any())
            {
                var topFiveBooksForEachBookCategory = new List<Book>();

                var bookCategoriesWithBooks = await UnitOfWork.BookCategoryRepository.FindAllAsync(
                    c =>
                    c.SubMainCategory.Name.Equals(subMainCategoryName) &&
                    c.SubMainCategory.MainCategory.Name.Equals(mainCategoryName) &&
                    c.Books.Any());
                var bookCategoriesWithBooksList = bookCategoriesWithBooks.ToList();

                foreach (var bookCategory in bookCategoriesWithBooksList)
                {
                    var books = await UnitOfWork.BookRepository.FindAllAsync(b => b.BookCategories.Any(c => c.Name.Equals(bookCategory.Name)) && b.Bestseller.Value, null, null, 5);
                    topFiveBooksForEachBookCategory.AddRange(books);
                }

                return new BooksForSubMainCategoryViewModel
                {
                    BookCategories = currentSubMainCategory.BookCategories,
                    BookCategoriesWithBooks = bookCategoriesWithBooksList,
                    BooksForSubMainCategory = topFiveBooksForEachBookCategory,
                    CurrentMainCategory = currentMainCategory,
                    CurrentSubMainCategory = currentSubMainCategory
                };
            }

            return new BooksForSubMainCategoryViewModel
            {
                BooksForSubMainCategory = currentSubMainCategory.Books,
                CurrentMainCategory = currentMainCategory,
                CurrentSubMainCategory = currentSubMainCategory
            };
        }

        public async Task<BooksForBookCategoryViewModel> GetBooksForBookCategory(int page, int itemsPerPage, string mainCategoryName,
            string subMainCategoryName, string bookCategoryName, string sortOrder = null)
        {

            var currentMainCategory = await GetCurrentMainCategory(mainCategoryName);
            var currentSubMainCategory = await GetCurrentSubMainCategory(mainCategoryName, subMainCategoryName);
            var currentBookCategory = await UnitOfWork.BookCategoryRepository.SingleOrDefaultAsync(
                bc => bc.SubMainCategory.MainCategory.Name.Equals(mainCategoryName) &&
                      bc.SubMainCategory.Name.Equals(subMainCategoryName) &&
                      bc.Name.Equals(bookCategoryName));

            var books = await UnitOfWork.BookRepository.FindAllAsync(b => b.BookCategories.Any(
                bc => bc.SubMainCategory.MainCategory.Name.Equals(mainCategoryName) &&
                      bc.SubMainCategory.Name.Equals(subMainCategoryName) &&
                      bc.Name.Equals(bookCategoryName)));

            if (sortOrder != null)
                books = SortOrder(sortOrder, books);


            return new BooksForBookCategoryViewModel
            {
                Books = books.ToPagedList(page, itemsPerPage),
                BookCategories = currentSubMainCategory.BookCategories,
                CurrentMainCategory = currentMainCategory,
                CurrentSubMainCategory = currentSubMainCategory,
                CurrentBookCategory = currentBookCategory,
                CurrentItemsPerPage = itemsPerPage,
                CurrentSortOrder = sortOrder
            };
        }
        
        public async Task<Book> GetFirstBookById(int bookId)
            => await UnitOfWork.BookRepository.FirstOrDefaultAsync(b => b.BookId == bookId);

        public async Task<BooksBySearchStringViewModel> GetBooksBySearchString(int page, int itemsPerPage, string searchString, string sortOrder = null)
        {
            var books =
                await
                    UnitOfWork.BookRepository.FindAllAsync(
                        b =>
                            b.TitleForDisplay.Contains(searchString) ||
                            b.Author.Any(
                                a => a.LastNameForDisplay.Contains(searchString) || a.FirstName.Contains(searchString)));

            if (sortOrder != null)
                books = SortOrder(sortOrder, books);

            return new BooksBySearchStringViewModel
            {
                Books = books.ToPagedList(page, itemsPerPage),
                SearchString = searchString,
                CurrentItemsPerPage = itemsPerPage,
                CurrentSortOrder = sortOrder
            };
        }

        private async Task<MainCategory> GetCurrentMainCategory(string mainCategoryName) 
            => await UnitOfWork.MainCategoryRepository.SingleOrDefaultAsync(mc => mc.Name.Equals(mainCategoryName));

        private async Task<SubMainCategory> GetCurrentSubMainCategory(string mainCategoryName, string subMainCategoryName)
            =>
                await
                    UnitOfWork.SubMainCategoryRepository.SingleOrDefaultAsync(
                        sc => sc.Name.Equals(subMainCategoryName) && sc.MainCategory.Name.Equals(mainCategoryName));

        private static IEnumerable<Book> SortOrder(string sortOrder, IEnumerable<Book> books)
        {
            switch (sortOrder)
            {
                case "Tytuł A-Z":
                    books = books.OrderBy(b => b.Title);
                    break;
                case "Tytuł Z-A":
                    books = books.OrderByDescending(b => b.Title);
                    break;
                case "Cena rosnąco":
                    books = books.OrderBy(b => b.Price);
                    break;
                case "Cena malejąco":
                    books = books.OrderByDescending(b => b.Price);
                    break;
                default:
                    books = books.OrderBy(b => b.BookId);
                    break;
            }

            return books;
        }
    }
}