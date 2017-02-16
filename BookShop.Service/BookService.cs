using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using BookShop.Data;
using BookShop.Models.QueryString;
using BookShop.Models.ViewModels;
using BookShop.Models.ViewModels.Books;
using BookShop.Repository.Interfaces;
using BookShop.Service.Interfaces;
using BookShop.Service.PatternMatching.BookSearch;
using PagedList;

namespace BookShop.Service
{
    public class BookService : GenericService<Book>, IBookService
    {
        private readonly IPatternMatchingBookSearch _patternMatchingBookSearch;
        public BookService(IUnitOfWork unitOfWork, IPatternMatchingBookSearch patternMatchingBookSearch) : base(unitOfWork)
        {
            _patternMatchingBookSearch = patternMatchingBookSearch;
        }


        public async Task<IEnumerable<BookIndexViewModel>> GetAll()
        {
            var books = await UnitOfWork.BookRepository.GetAll();
            return books.Select(BookToBookIndexViewModel);
        }


        //Książki dla głównych kategorii
        public async Task<BooksForMainCategoryViewModel> GetBooksForMainCategory(string mainCategoryName)
        {
            var topFiveBooksForEachSubMainCategory = new List<Book>();

            //aktualnie wybrana główna kategoria
            var currentMainCategory = await GetCurrentMainCategory(mainCategoryName);

            //jej podkateorie, które maja książki, bo nie wszystkie maja poki co
            var subMainCategoriesWithBooks =
                await
                    UnitOfWork.SubMainCategoryRepository.FindAll(
                        s => s.MainCategory.Name.Equals(mainCategoryName) && s.Books.Any());
            var subMainCategoriesWithBooksList = subMainCategoriesWithBooks.ToList();

            foreach (var subMainCategory in subMainCategoriesWithBooksList)
            {
                var books =
                    await
                        UnitOfWork.BookRepository.FindAll(
                            b => b.Quantity > 0 && b.SubMainCategories.Any(s => s.Name.Equals(subMainCategory.Name) && s.MainCategory.Name.Equals(currentMainCategory.Name)) && b.Bestseller.Value,
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


        //Książki dla podkategorii głównej kategorii
        public async Task<BooksForSubMainCategoryViewModel> GetBooksForSubMainCategory(string mainCategoryName, 
            string subMainCategoryName, int page, int itemsPerPage, string sortOrder)
        {
            //aktualnie wybrana główna kategoria i jej podkategoria
            var currentMainCategory = await GetCurrentMainCategory(mainCategoryName);
            var currentSubMainCategory = await GetCurrentSubMainCategory(mainCategoryName, subMainCategoryName);

            if (currentSubMainCategory.BookCategories.Any())
            {
                var topFiveBooksForEachBookCategory = new List<Book>();

                //tylko te kategorie, które maja książki
                var bookCategoriesWithBooks = await UnitOfWork.BookCategoryRepository.FindAll(
                    c =>
                    c.SubMainCategory.Name.Equals(subMainCategoryName) &&
                    c.SubMainCategory.MainCategory.Name.Equals(mainCategoryName) &&
                    c.Books.Any(), c=>c.OrderBy(x=>x.Name));
                var bookCategoriesWithBooksList = bookCategoriesWithBooks.ToList();

                foreach (var bookCategory in bookCategoriesWithBooksList)
                {
                    var books = await UnitOfWork.BookRepository.FindAll(b => b.BookCategories.Any(c => c.Name.Equals(bookCategory.Name)) && 
                    b.Bestseller.Value && b.Quantity > 0, null, null, 5);
                    topFiveBooksForEachBookCategory.AddRange(books);
                }

                return new BooksForSubMainCategoryViewModel
                {
                    BookCategories = currentSubMainCategory.BookCategories.OrderBy(x => x.Name),
                    BookCategoriesWithBooks = bookCategoriesWithBooksList,
                    TopFiveBooksForEachBookCategory = topFiveBooksForEachBookCategory,
                    CurrentMainCategory = currentMainCategory,
                    CurrentSubMainCategory = currentSubMainCategory
                };
            }

            //jeśli podkategoria głównej kategorii nie ma swoich podkategorii to pobiera wszystkie nie tylko bestsellery
            var booksForSubMainCategory = await GetBooks(sortOrder, mainCategoryName, subMainCategoryName);

            return new BooksForSubMainCategoryViewModel
            {
                Books = booksForSubMainCategory.ToPagedList(page, itemsPerPage),
                CurrentMainCategory = currentMainCategory,
                CurrentSubMainCategory = currentSubMainCategory,
                CurrentItemsPerPage = itemsPerPage,
                CurrentSortOrder = sortOrder
            };
        }


        //Książki dla kategorii najbliższych
        public async Task<BooksForBookCategoryViewModel> GetBooksForBookCategory(string mainCategoryName, string subMainCategoryName, string bookCategoryName,
            int page, int itemsPerPage, string sortOrder)
        {
            //Aktualna głowna kategoria jej podkategoria i podkategoia podkategorii :D
            var currentMainCategory = await GetCurrentMainCategory(mainCategoryName);
            var currentSubMainCategory = await GetCurrentSubMainCategory(mainCategoryName, subMainCategoryName);
            var currentBookCategory = await UnitOfWork.BookCategoryRepository.SingleOrDefault(
                bc => bc.SubMainCategory.MainCategory.Name.Equals(mainCategoryName) &&
                      bc.SubMainCategory.Name.Equals(subMainCategoryName) &&
                      bc.Name.Equals(bookCategoryName));

            var books = await GetBooks(sortOrder, mainCategoryName, subMainCategoryName, bookCategoryName);

            return new BooksForBookCategoryViewModel
            {
                Books = books.ToPagedList(page, itemsPerPage),
                BookCategories = currentSubMainCategory.BookCategories.OrderBy(x => x.Name),
                CurrentMainCategory = currentMainCategory,
                CurrentSubMainCategory = currentSubMainCategory,
                CurrentBookCategory = currentBookCategory,
                CurrentItemsPerPage = itemsPerPage,
                CurrentSortOrder = sortOrder
            };
        }


        public async Task<BookViewModel> GetById(int id)
        {
            var book = await UnitOfWork.BookRepository.Find(id);
            return BookToBookViewModel(book);
        }


        public async Task<Book> GetBookById(int bookId)
            => await UnitOfWork.BookRepository.FirstOrDefault(b => b.Id == bookId);


        //Książki wyszukane przez fraze z wyszukiwarki
        public async Task<BooksBySearchStringViewModel> GetBooksBySearchString(QueryStringSearch queryModel)
        {
            //rezultat wyszukiwania
            var books = await _patternMatchingBookSearch.PatternMatchingQueryString(queryModel);

            return new BooksBySearchStringViewModel
            {
                Books = books,
                CurrentSearchString = queryModel.SearchString,
                CurrentSearchOption = queryModel.SearchOption,
                CurrentItemsPerPage = queryModel.ItemsPerPage,
                CurrentSortOrder = queryModel.SortOrder
            };
        }


        public async Task<BookPostViewModel> GetBookCreateViewModel()
        {
            var languages = Enum.GetValues(typeof(Language)).Cast<Language>().Select(GetDescription).ToList();
            var covers = Enum.GetValues(typeof(Cover)).Cast<Cover>().Select(GetDescription).ToList();
            var publishings = await UnitOfWork.PublishingRepository.GetAll();
            var authors = await UnitOfWork.AuthorRepository.GetAll();
            var bookCategories = await UnitOfWork.BookCategoryRepository.FindAll(b => b.SubMainCategory.Id == 1, b=>b.OrderBy(x=>x.NameForDisplay));

            var subMainCategories = await UnitOfWork.SubMainCategoryRepository.GetAll();
            var groupedSubMainCategories = subMainCategories.GroupBy(x=>x.MainCategory.NameForDisplay);

            var languagesSelectList = languages.Select(l => new SelectListItem
            {
                Value = l,
                Text = l
            });

            var coversSelectList = covers.Select(c => new SelectListItem
            {
                Value = c,
                Text = c
            });

            var publishingSelectList = publishings.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(CultureInfo.InvariantCulture),
                Text = p.NameForDisplay
            });

            var authorSelectList = authors.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(CultureInfo.InvariantCulture),
                Text = a.FirstName + " " + a.LastNameForDisplay
            });

            //var bookCategorySelectList = bookCategories.Select(b => new SelectListItem
            //{
            //    Value = b.Id.ToString(CultureInfo.InvariantCulture),
            //    Text = b.NameForDisplay
            //});
            var bookCategorySelectList = new List<SelectListItem>();
            var vm = new BookPostViewModel
            {
                LanguagesSelectList = languagesSelectList,
                CoversSelectList = coversSelectList,
                PublishingSelectList = publishingSelectList,
                AuthorSelectList = authorSelectList,
                BookCategorySelectList = bookCategorySelectList,
                SubMainCategorySelectList = new List<SelectListItem>()
            };

            //grupujemy podkategorie pod względem głównych kategorii
            foreach (var mainCategory in groupedSubMainCategories)
            {
                var optGroup = new SelectListGroup { Name = mainCategory.Key };
                foreach (var subMainCategory in mainCategory)
                {
                    vm.SubMainCategorySelectList.Add(new SelectListItem
                    {
                        Value = subMainCategory.Id.ToString(CultureInfo.InvariantCulture),
                        Text = subMainCategory.NameForDisplay,
                        Group = optGroup
                    });
                }
            }

            return vm;
        }


        public async Task<BookPostResponseViewModel> Create(BookPostViewModel book)
        {
            var bookExists = await UnitOfWork.BookRepository.Any(x => x.ISBN.Equals(book.ISBN));

            //Jeśli książka już istneje to nie ma sensu jej dodawać
            if (bookExists)
            {
                var result =
                    await UnitOfWork.BookRepository.SingleOrDefault(x => x.ISBN.Equals(book.ISBN));
                return new BookPostResponseViewModel
                {
                    Id = result.Id,
                    Title = result.Title,
                    SubMainCategoryName = result.SubMainCategories.First().Name,
                    MainCategoryName = result.SubMainCategories.First().MainCategory.Name
                };
            }

            var authors = new List<Author>();
            var subMainCategories = new List<SubMainCategory>();
            var bookCategories = new List<BookCategory>();

            foreach (var authorId in book.Authors)
            {
                var author = await UnitOfWork.AuthorRepository.Find(authorId);
                authors.Add(author);
            }

            foreach (var subMainCategoryId in book.SubMainCategoryies)
            {
                var subMainCategory = await UnitOfWork.SubMainCategoryRepository.Find(subMainCategoryId);
                subMainCategories.Add(subMainCategory);
            }

            if (book.BookCategories != null)
            {
                foreach (var bookCategoryId in book.BookCategories)
                {
                    var bookCategory = await UnitOfWork.BookCategoryRepository.Find(bookCategoryId);
                    bookCategories.Add(bookCategory);
                }
            }

            var postBook = BookPostViewModelToBook(book, authors, subMainCategories, bookCategories);

            var newBook = await UnitOfWork.BookRepository.Add(postBook);

            return new BookPostResponseViewModel
            {
                Id = newBook.Id,
                Title = newBook.Title,
                SubMainCategoryName = newBook.SubMainCategories.First().Name,
                MainCategoryName = newBook.SubMainCategories.First().MainCategory.Name
            };
        }


        public async Task<BookEditViewModel> GetBookEditViewModel(int id)
        {
            var book = await UnitOfWork.BookRepository.Find(id);
            var languages = Enum.GetValues(typeof(Language)).Cast<Language>().Select(GetDescription).ToList();
            var covers = Enum.GetValues(typeof(Cover)).Cast<Cover>().Select(GetDescription).ToList();
            var publishings = await UnitOfWork.PublishingRepository.GetAll();
            var authors = await UnitOfWork.AuthorRepository.GetAll();
            var bookCategories = book.SubMainCategories.SelectMany(s => s.BookCategories);

            var subMainCategories = await UnitOfWork.SubMainCategoryRepository.GetAll();
            var groupedSubMainCategories = subMainCategories.GroupBy(x => x.MainCategory.NameForDisplay);

            var languagesSelectList = languages.Select(l => new SelectListItem
            {
                Value = l,
                Text = l,
                Selected = l == GetDescription(book.Language)
            });

            var coversSelectList = covers.Select(c => new SelectListItem
            {
                Value = c,
                Text = c,
                Selected = c == GetDescription(book.Cover)
            });

            var publishingSelectList = publishings.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(CultureInfo.InvariantCulture),
                Text = p.NameForDisplay,
                Selected = p.Id == book.PublishingId
            });

            var authorSelectList = authors.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(CultureInfo.InvariantCulture),
                Text = a.FirstName + " " + a.LastNameForDisplay,
                Selected = SelectedAuthor(a.Id, book.Author)
            });

            var bookCategorySelectList = bookCategories.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(CultureInfo.InvariantCulture),
                Text = b.NameForDisplay,
                Selected = SelectedBookCategory(b.Id, book.BookCategories)
            });

            var vm = new BookEditViewModel
            {
                Id = book.Id,
                Bestseller = book.Bestseller,
                Cover = GetDescription(book.Cover),
                TitleForDisplay = book.TitleForDisplay,
                BookSize = book.BookSize,
                Description = book.Description,
                ISBN = book.ISBN,
                Image = book.Image,
                Language = GetDescription(book.Language),
                PageSize = book.PageSize,
                Price = book.Price.ToString(CultureInfo.InvariantCulture),
                PublishDate = book.PublishDate.ToString("dd'/'MM'/'yyyy"),
                PublishingId = book.PublishingId,
                Quantity = book.Quantity,
                Title = book.Title,
                BookCategories = book.BookCategories.Select(x=>x.Id).ToList(),
                Authors = book.Author.Select(x=>x.Id).ToList(),
                SubMainCategoryies = book.SubMainCategories.Select(x=>x.Id).ToList(),
                LanguagesSelectList = languagesSelectList,
                CoversSelectList = coversSelectList,
                PublishingSelectList = publishingSelectList,
                AuthorSelectList = authorSelectList,
                BookCategorySelectList = bookCategorySelectList,
                SubMainCategorySelectList = new List<SelectListItem>()
            };

            //grupujemy podkategorie pod względem głównych kategorii
            foreach (var mainCategory in groupedSubMainCategories)
            {
                var optGroup = new SelectListGroup { Name = mainCategory.Key };
                foreach (var subMainCategory in mainCategory)
                {
                    vm.SubMainCategorySelectList.Add(new SelectListItem
                    {
                        Value = subMainCategory.Id.ToString(CultureInfo.InvariantCulture),
                        Text = subMainCategory.NameForDisplay,
                        Group = optGroup,
                        Selected = SelectedSubMainCategory(subMainCategory.Id, book.SubMainCategories)
                    });
                }
            }

            return vm;
        }


        public async Task<BookPostResponseViewModel> Edit(BookEditViewModel book)
        {
            var authors = new List<Author>();
            var subMainCategories = new List<SubMainCategory>();
            var bookCategories = new List<BookCategory>();

            foreach (var authorId in book.Authors)
            {
                var author = await UnitOfWork.AuthorRepository.Find(authorId);
                authors.Add(author);
            }

            foreach (var subMainCategoryId in book.SubMainCategoryies)
            {
                var subMainCategory = await UnitOfWork.SubMainCategoryRepository.Find(subMainCategoryId);
                subMainCategories.Add(subMainCategory);
            }

            if (book.BookCategories != null)
            {
                foreach (var bookCategoryId in book.BookCategories)
                {
                    var bookCategory = await UnitOfWork.BookCategoryRepository.Find(bookCategoryId);
                    bookCategories.Add(bookCategory);
                }
            }

            var mappedBook = BookPostViewModelToBook(book, authors, subMainCategories, bookCategories);
            var bookToUpdate = mappedBook;
            bookToUpdate.Id = book.Id;
            await UnitOfWork.BookRepository.Update(bookToUpdate);

            return new BookPostResponseViewModel
            {
                Id = bookToUpdate.Id,
                Title = bookToUpdate.Title,
                SubMainCategoryName = bookToUpdate.SubMainCategories.First().Name,
                MainCategoryName = bookToUpdate.SubMainCategories.First().MainCategory.Name
            };
        }


        //Zwraca kategorie najbliższe dla select listy w zależności od wybranej podkategorii głównej kategorii
        public async Task<IEnumerable<BookCategoriesSelectList>> GetBookCategories(string[] subMainCategoryIdList)
        {
            var vmList = new List<BookCategoriesSelectList>();

            if (string.IsNullOrEmpty(subMainCategoryIdList?[0]))
            {
                vmList.Add(new BookCategoriesSelectList
                {
                    Text = string.Empty
                });

                return vmList;
            }

            var selectedBookCategories = new List<BookCategory>();

            var subMainCategoryIdStringList = subMainCategoryIdList?[0].Split(',');
            var subMainCategoryIdIntList = subMainCategoryIdStringList.Select(int.Parse);

            foreach (var id in subMainCategoryIdIntList)
            {
                var subMainCategory = await UnitOfWork.SubMainCategoryRepository.SingleOrDefault(s => s.Id == id);
                selectedBookCategories.AddRange(subMainCategory.BookCategories);
            }

            var groupedBookCategories = selectedBookCategories.GroupBy(x => x.SubMainCategory.Id);


            //grupujemy kategorie pod względem podkategorii
            foreach (var subMainCategory in groupedBookCategories)
            {
                var submainCategoruId = subMainCategory.Key;
                var selectedSubMainCategory = await UnitOfWork.SubMainCategoryRepository.SingleOrDefault(s => s.Id == submainCategoruId);

                var optGroup = selectedSubMainCategory.NameForDisplay + " - " + selectedSubMainCategory.MainCategory.NameForDisplay;
                
                var bookCategories = selectedBookCategories.Where(x => x.SubMainCategory.Id == submainCategoruId).Where(x => x.SubMainCategory.Id == submainCategoruId).Select(x => new SelectListViewModel
                {
                    Id = x.Id.ToString(CultureInfo.InvariantCulture),
                    Text = x.NameForDisplay
                });

                vmList.Add(new BookCategoriesSelectList
                {
                    Text = optGroup,
                    Children = bookCategories
                });
            }

            return vmList;
        }


        public async Task<bool> Exists(int id)
            => await UnitOfWork.BookRepository.Any(b => b.Id == id);


        //Jeśli ktoś wpisał błędne nazwy głównej kategorii podkategori albo kategorii najbliższej to error
        public async Task<bool> BadRequest(string mainCategoryName, string subMainCategoryName = null, string bookCategoryName = null)
        {
            if (await MainCategoryNotExists(mainCategoryName))
                return true;

            var mainCategory =
                await UnitOfWork.MainCategoryRepository.SingleOrDefault(m => m.Name.Equals(mainCategoryName));
            if (!string.IsNullOrEmpty(subMainCategoryName) && string.IsNullOrEmpty(bookCategoryName))
            {
                return MainCategoryHasNotSubMainCategory(mainCategory, subMainCategoryName);
            }

            if (!string.IsNullOrEmpty(subMainCategoryName) && !string.IsNullOrEmpty(bookCategoryName))
            {
                return MainCategoryHasNotSubMainCategory(mainCategory, subMainCategoryName) ||
                       SubMainCategoryHasNotBookCategory(mainCategory, subMainCategoryName, bookCategoryName);
            }
            return false;
        }


        public async Task<InfoViewModel> Delete(int id)
        {
            var book = await UnitOfWork.BookRepository.Find(id);
            await UnitOfWork.BookRepository.Remove(book);

            return new InfoViewModel
            {
                Message = "Książka " + book.TitleForDisplay + " została usunięta"
            };
        }


        public async Task SetBestseller(int id)
        {
            var book = await UnitOfWork.BookRepository.Find(id);
            book.Bestseller = true;
            await UnitOfWork.BookRepository.Update(book);
        }


        public async Task RemoveBestseller(int id)
        {
            var book = await UnitOfWork.BookRepository.Find(id);
            book.Bestseller = false;
            await UnitOfWork.BookRepository.Update(book);
        }


        #region Helpers

        private bool SelectedSubMainCategory(int subMainCategoryId, IEnumerable<SubMainCategory> subMainCategories)
            => subMainCategories.Any(s => s.Id == subMainCategoryId);


        private bool SelectedBookCategory(int bookCategoryId, IEnumerable<BookCategory> bookCategories)
            => bookCategories.Any(b => b.Id == bookCategoryId);


        private bool SelectedAuthor(int authorId, IEnumerable<Author> authors)
            => authors.Any(a => a.Id == authorId);


        private async Task<bool> MainCategoryNotExists(string mainCategoryName)
            => !await UnitOfWork.MainCategoryRepository.Any(m => m.Name.Equals(mainCategoryName));


        private static bool MainCategoryHasNotSubMainCategory(MainCategory mainCategory, string subMainCategoryName)
            => !mainCategory.SubMainCategories.Any(s => s.Name.Equals(subMainCategoryName));


        private static bool SubMainCategoryHasNotBookCategory(MainCategory mainCategory, string subMainCategoryName, string bookCategoryName)
        {
            var subMainCategory = mainCategory.SubMainCategories.SingleOrDefault(s => s.Name.Equals(subMainCategoryName));
            return !subMainCategory.BookCategories.Any(b => b.Name.Equals(bookCategoryName));
        }


        private async Task<MainCategory> GetCurrentMainCategory(string mainCategoryName)
            => await UnitOfWork.MainCategoryRepository.SingleOrDefault(mc => mc.Name.Equals(mainCategoryName));


        private async Task<SubMainCategory> GetCurrentSubMainCategory(string mainCategoryName, string subMainCategoryName)
            =>
                await
                    UnitOfWork.SubMainCategoryRepository.SingleOrDefault(
                        sc => sc.Name.Equals(subMainCategoryName) && sc.MainCategory.Name.Equals(mainCategoryName));


        private async Task<IEnumerable<Book>> GetBooks(string sortOrder, string mainCategoryName, string subMainCategoryName)
        {
            var currentSubMainCategory = await GetCurrentSubMainCategory(mainCategoryName, subMainCategoryName);
            IEnumerable<Book> books = currentSubMainCategory.Books.Where(b => b.Quantity > 0);
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
                    books = books.OrderBy(b => b.Id);
                    break;
            }

            return books;
        }


        private async Task<IEnumerable<Book>> GetBooks(string sortOrder, string mainCategoryName, string subMainCategoryName, string bookCategoryName)
        {
            IEnumerable<Book> books;
            switch (sortOrder)
            {
                case "Tytuł A-Z":
                    books = await UnitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.Name.Equals(mainCategoryName) &&
                            bc.SubMainCategory.Name.Equals(subMainCategoryName) &&
                            bc.Name.Equals(bookCategoryName)),
                        bc => bc.OrderBy(b => b.Title));
                    break;
                case "Tytuł Z-A":
                    books = await UnitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.Name.Equals(mainCategoryName) &&
                            bc.SubMainCategory.Name.Equals(subMainCategoryName) &&
                            bc.Name.Equals(bookCategoryName)),
                        bc => bc.OrderByDescending(b => b.Title));
                    break;
                case "Cena rosnąco":
                    books = await UnitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.Name.Equals(mainCategoryName) &&
                            bc.SubMainCategory.Name.Equals(subMainCategoryName) &&
                            bc.Name.Equals(bookCategoryName)),
                        bc => bc.OrderBy(b => b.Price));
                    break;
                case "Cena malejąco":
                    books = await UnitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.Name.Equals(mainCategoryName) &&
                            bc.SubMainCategory.Name.Equals(subMainCategoryName) &&
                            bc.Name.Equals(bookCategoryName)),
                        bc => bc.OrderByDescending(b => b.Price));
                    break;
                default:
                    books = await UnitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.Name.Equals(mainCategoryName) &&
                            bc.SubMainCategory.Name.Equals(subMainCategoryName) &&
                            bc.Name.Equals(bookCategoryName)),
                        bc => bc.OrderBy(b => b.Id));
                    break;
            }

            return books;
        }


        private BookViewModel BookToBookViewModel(Book book)
            => new BookViewModel
            {
                Author = book.Author,
                BookId = book.Id,
                TitleForDisplay = book.TitleForDisplay,
                Price = book.Price.ToString("c"),
                Publishing = book.Publishing,
                SubMainCategories = book.SubMainCategories,
                BookCategories = book.BookCategories,
                Description = book.Description,
                BookReviews = book.BookReviews,
                PageSize = book.PageSize,
                Language = GetDescription(book.Language),
                Cover = GetDescription(book.Cover),
                Bestseller = book.Bestseller,
                BookSize = book.BookSize,
                ISBN = book.ISBN,
                Image = book.Image,
                PublishDate = book.PublishDate
            };


        private BookIndexViewModel BookToBookIndexViewModel(Book book)
            => new BookIndexViewModel
            {
                MainCategoryName = book.SubMainCategories.FirstOrDefault().MainCategory.Name,
                SubMainCategoryName = book.SubMainCategories.FirstOrDefault().Name,
                Title = book.Title,
                Id = book.Id,
                TitleForDisplay = book.TitleForDisplay,
                Authors = book.Author,
                Bestseller = book.Bestseller,
                Cover = GetDescription(book.Cover),
                Quantity = book.Quantity,
                Price = book.Price.ToString("c")
            };

        private Book BookPostViewModelToBook(BookPostViewModel book, List<Author> authors, List<SubMainCategory> subMainCategories, List<BookCategory> bookCategories)
            => new Book
            {
                Bestseller = book.Bestseller,
                BookSize = book.BookSize,
                Cover = GetCover(book.Cover),
                Language = GetLaguage(book.Language),
                Description = book.Description,
                ISBN = book.ISBN,
                Image = book.Image,
                PageSize = book.PageSize,
                Price = decimal.Parse(book.Price, CultureInfo.InvariantCulture),
                PublishDate = DateTime.ParseExact(book.PublishDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                PublishingId = book.PublishingId,
                Quantity = book.Quantity,
                Title = book.Title,
                TitleForDisplay = book.TitleForDisplay,
                Author = authors,
                SubMainCategories = subMainCategories,
                BookCategories = bookCategories
            };


        //private static string SetLaguage(Language language)
        //{
        //    switch (language)
        //    {
        //        case Language.Czech:
        //            return "Czeski";
        //        case Language.English:
        //            return "Angielski";
        //        case Language.French:
        //            return "Francuski";
        //        case Language.German:
        //            return "Niemiecki";
        //        default:
        //            return "Polski";
        //    }
        //}

        private static Language GetLaguage(string language)
        {
            switch (language)
            {
                case "Czeski":
                    return Language.Czech;
                case "Angielski":
                    return Language.English;
                case "Francuski":
                    return Language.French;
                case "Niemiecki":
                    return Language.German;
                default:
                    return Language.Polish;
            }
        }


        //private static string SetCover(Cover cover)
        //{
        //    switch (cover)
        //    {
        //        case Cover.HardCover:
        //            return "Twarda";
        //        case Cover.SoftCover:
        //            return "Miękka";
        //        default:
        //            return "Brak"; ;
        //    }
        //}
        //private static string SetCover(Cover cover)
        //{
        //    var type = typeof(Cover);
        //    var memInfo = type.GetMember(cover.ToString());
        //    var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute),
        //        false);
        //    return ((DescriptionAttribute)attributes[0]).Description;
        //}


        private static Cover GetCover(string cover)
        {
            switch (cover)
            {
                case "Twarda":
                    return Cover.HardCover;
                case "Miękka":
                    return Cover.SoftCover;
                default:
                    return Cover.None;
            }
        }

        #endregion
    }
}