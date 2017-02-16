using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Models.QueryString;
using BookShop.Repository.Interfaces;
using PagedList;

namespace BookShop.Service.PatternMatching.BookSearch
{
    public class PatternMatchingBookSearch : IPatternMatchingBookSearch
    {
        private static IUnitOfWork _unitOfWork;

        /// <summary>
        /// Lista przechowująca powiązania wzór-odpowiedź
        /// </summary>
        public List<PatternMatchBookSearch> PatternMatchQueryString { get; } =
            new List<PatternMatchBookSearch>
            {
                new PatternMatchBookSearch(Pattern1, Match1),
                new PatternMatchBookSearch(Pattern2, Match2),
                new PatternMatchBookSearch(Pattern3, Match3),
                new PatternMatchBookSearch(Pattern4, Match4),
                new PatternMatchBookSearch(Pattern5, Match5),
                new PatternMatchBookSearch(Pattern6, Match6),
                new PatternMatchBookSearch(Pattern7, Match7),
                new PatternMatchBookSearch(Pattern8, Match8),
                new PatternMatchBookSearch(Pattern9, Match9),
                new PatternMatchBookSearch(Pattern10, Match10),
                new PatternMatchBookSearch(Pattern11, Match11),
                new PatternMatchBookSearch(Pattern12, Match12),
                new PatternMatchBookSearch(Pattern13, Match13),
                new PatternMatchBookSearch(Pattern14, Match14),
                new PatternMatchBookSearch(Pattern15, Match15),
                new PatternMatchBookSearch(Pattern16, Match16),
                new PatternMatchBookSearch(Pattern17, Match17),
                new PatternMatchBookSearch(Pattern18, Match18),
                new PatternMatchBookSearch(Pattern19, Match19),
                new PatternMatchBookSearch(Pattern20, Match20),
                new PatternMatchBookSearch(Pattern21, Match21),
                new PatternMatchBookSearch(Pattern22, Match22),
                new PatternMatchBookSearch(Pattern23, Match23),
                new PatternMatchBookSearch(Pattern24, Match24),
                new PatternMatchBookSearch(Pattern25, Match25),
                new PatternMatchBookSearch(Pattern26, Match26),
                new PatternMatchBookSearch(Pattern27, Match27),
                new PatternMatchBookSearch(Pattern28, Match28),
                new PatternMatchBookSearch(Pattern29, Match29),
                new PatternMatchBookSearch(Pattern30, Match30),
                new PatternMatchBookSearch(Pattern31, Match31),
                new PatternMatchBookSearch(Pattern32, Match32),
                new PatternMatchBookSearch(Pattern33, Match33),
                new PatternMatchBookSearch(Pattern34, Match34),
                new PatternMatchBookSearch(Pattern35, Match35),
                new PatternMatchBookSearch(Pattern36, Match36),
                new PatternMatchBookSearch(Pattern37, Match37),
                new PatternMatchBookSearch(Pattern38, Match38),
                new PatternMatchBookSearch(Pattern39, Match39),
                new PatternMatchBookSearch(Pattern40, Match40),
                new PatternMatchBookSearch(Pattern41, Match41),
                new PatternMatchBookSearch(Pattern42, Match42),
                new PatternMatchBookSearch(Pattern43, Match43),
                new PatternMatchBookSearch(Pattern44, Match44),
                new PatternMatchBookSearch(Pattern45, Match45)
            };

        public PatternMatchingBookSearch(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Akcja wyszukiwania i odpowiedzi
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public async Task<IPagedList<Book>> PatternMatchingQueryString(QueryStringSearch queryModel)
        {
            var match = PatternMatchQueryString.FirstOrDefault(d => d.CheckPatternQueryString(queryModel));
            if (match != null)
                return await match.UseMatchQueryString(queryModel);

            return null;
        }

        private static bool Pattern1(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Wszędzie") && queryModel.SortOrder.Equals("Sortuj");

        private static async Task<IPagedList<Book>> Match1(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Id));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern2(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Wszędzie") && queryModel.SortOrder.Equals("Tytuł A-Z");

        private static async Task<IPagedList<Book>> Match2(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Title));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern3(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Wszędzie") && queryModel.SortOrder.Equals("Tytuł Z-A");

        private static async Task<IPagedList<Book>> Match3(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderByDescending(x => x.Title));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern4(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Wszędzie") && queryModel.SortOrder.Equals("Cena rosnąco");

        private static async Task<IPagedList<Book>> Match4(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Price));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern5(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Wszędzie") && queryModel.SortOrder.Equals("Cena malejąco");

        private static async Task<IPagedList<Book>> Match5(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderByDescending(x => x.Price));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern6(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Książki") && queryModel.SortOrder.Equals("Sortuj");

        private static async Task<IPagedList<Book>> Match6(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Książki")) && 
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Id));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern7(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Książki") && queryModel.SortOrder.Equals("Tytuł A-Z");

        private static async Task<IPagedList<Book>> Match7(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Książki")) && 
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Title));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern8(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Książki") && queryModel.SortOrder.Equals("Tytuł Z-A");

        private static async Task<IPagedList<Book>> Match8(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Książki")) && 
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderByDescending(x => x.Title));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern9(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Książki") && queryModel.SortOrder.Equals("Cena rosnąco");

        private static async Task<IPagedList<Book>> Match9(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Książki")) &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Price));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern10(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Książki") && queryModel.SortOrder.Equals("Cena malejąco");

        private static async Task<IPagedList<Book>> Match10(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Książki")) &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderByDescending(x => x.Price));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern11(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Podręczniki") && queryModel.SortOrder.Equals("Sortuj");

        private static async Task<IPagedList<Book>> Match11(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Podręczniki")) &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Id));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern12(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Podręczniki") && queryModel.SortOrder.Equals("Tytuł A-Z");

        private static async Task<IPagedList<Book>> Match12(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Podręczniki")) &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Title));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern13(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Podręczniki") && queryModel.SortOrder.Equals("Tytuł Z-A");

        private static async Task<IPagedList<Book>> Match13(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Podręczniki")) &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderByDescending(x => x.Title));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern14(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Podręczniki") && queryModel.SortOrder.Equals("Cena rosnąco");

        private static async Task<IPagedList<Book>> Match14(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Podręczniki")) &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Price));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern15(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Podręczniki") && queryModel.SortOrder.Equals("Cena malejąco");

        private static async Task<IPagedList<Book>> Match15(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Podręczniki")) &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderByDescending(x => x.Price));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern16(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Ebooki") && queryModel.SortOrder.Equals("Sortuj");

        private static async Task<IPagedList<Book>> Match16(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Ebooki")) &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Id));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern17(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Ebooki") && queryModel.SortOrder.Equals("Tytuł A-Z");

        private static async Task<IPagedList<Book>> Match17(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Ebooki")) &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Title));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern18(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Ebooki") && queryModel.SortOrder.Equals("Tytuł Z-A");

        private static async Task<IPagedList<Book>> Match18(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Ebooki")) &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderByDescending(x => x.Title));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern19(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Ebooki") && queryModel.SortOrder.Equals("Cena rosnąco");

        private static async Task<IPagedList<Book>> Match19(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Ebooki")) &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Price));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern20(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Ebooki") && queryModel.SortOrder.Equals("Cena malejąco");

        private static async Task<IPagedList<Book>> Match20(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Ebooki")) &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderByDescending(x => x.Price));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern21(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Audiobooki") && queryModel.SortOrder.Equals("Sortuj");

        private static async Task<IPagedList<Book>> Match21(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Audiobooki")) &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Id));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern22(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Audiobooki") && queryModel.SortOrder.Equals("Tytuł A-Z");

        private static async Task<IPagedList<Book>> Match22(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Audiobooki")) &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Title));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern23(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Audiobooki") && queryModel.SortOrder.Equals("Tytuł Z-A");

        private static async Task<IPagedList<Book>> Match23(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Audiobooki")) &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderByDescending(x => x.Title));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern24(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Audiobooki") && queryModel.SortOrder.Equals("Cena rosnąco");

        private static async Task<IPagedList<Book>> Match24(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Audiobooki")) &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Price));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern25(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Audiobooki") && queryModel.SortOrder.Equals("Cena malejąco");

        private static async Task<IPagedList<Book>> Match25(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Audiobooki")) &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderByDescending(x => x.Price));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern26(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Komiksy") && queryModel.SortOrder.Equals("Sortuj");

        private static async Task<IPagedList<Book>> Match26(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Komiksy")) &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Id));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern27(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Komiksy") && queryModel.SortOrder.Equals("Tytuł A-Z");

        private static async Task<IPagedList<Book>> Match27(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Komiksy")) &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Title));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern28(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Komiksy") && queryModel.SortOrder.Equals("Tytuł Z-A");

        private static async Task<IPagedList<Book>> Match28(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Komiksy")) &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderByDescending(x => x.Title));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern29(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Komiksy") && queryModel.SortOrder.Equals("Cena rosnąco");

        private static async Task<IPagedList<Book>> Match29(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Komiksy")) &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Price));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern30(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Komiksy") && queryModel.SortOrder.Equals("Cena malejąco");

        private static async Task<IPagedList<Book>> Match30(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.BookCategories.Any(
                        bc => bc.SubMainCategory.MainCategory.NameForDisplay.Equals("Komiksy")) &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderByDescending(x => x.Price));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern31(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Bestsellery") && queryModel.SortOrder.Equals("Sortuj");

        private static async Task<IPagedList<Book>> Match31(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.Bestseller.Value &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Id));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern32(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Bestsellery") && queryModel.SortOrder.Equals("Tytuł A-Z");

        private static async Task<IPagedList<Book>> Match32(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.Bestseller.Value &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Title));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern33(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Bestsellery") && queryModel.SortOrder.Equals("Tytuł Z-A");

        private static async Task<IPagedList<Book>> Match33(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.Bestseller.Value &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderByDescending(x => x.Title));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern34(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Bestsellery") && queryModel.SortOrder.Equals("Cena rosnąco");

        private static async Task<IPagedList<Book>> Match34(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.Bestseller.Value &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Price));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern35(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Bestsellery") && queryModel.SortOrder.Equals("Cena malejąco");

        private static async Task<IPagedList<Book>> Match35(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.Bestseller.Value &&
                        (b.TitleForDisplay.Contains(queryModel.SearchString) ||
                                                              b.Author.Any(
                                                                  a =>
                                                                      a.FirstName.Contains(queryModel.SearchString) ||
                                                                      a.LastNameForDisplay.Contains(
                                                                          queryModel.SearchString)) ||
                                                              b.Publishing.NameForDisplay.Contains(
                                                                  queryModel.SearchString) ||
                                                              b.Description.Contains(queryModel.SearchString)),
                    b => b.OrderByDescending(x => x.Price));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern36(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Autorzy") && queryModel.SortOrder.Equals("Sortuj");

        private static async Task<IPagedList<Book>> Match36(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.Author.Any(a => a.FirstName.Contains(queryModel.SearchString) || a.LastNameForDisplay.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Id));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern37(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Autorzy") && queryModel.SortOrder.Equals("Tytuł A-Z");

        private static async Task<IPagedList<Book>> Match37(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.Author.Any(a => a.FirstName.Contains(queryModel.SearchString) || a.LastNameForDisplay.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Title));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern38(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Autorzy") && queryModel.SortOrder.Equals("Tytuł Z-A");

        private static async Task<IPagedList<Book>> Match38(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.Author.Any(a => a.FirstName.Contains(queryModel.SearchString) || a.LastNameForDisplay.Contains(queryModel.SearchString)),
                    b => b.OrderByDescending(x => x.Title));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern39(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Autorzy") && queryModel.SortOrder.Equals("Cena rosnąco");

        private static async Task<IPagedList<Book>> Match39(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.Author.Any(a => a.FirstName.Contains(queryModel.SearchString) || a.LastNameForDisplay.Contains(queryModel.SearchString)),
                    b => b.OrderBy(x => x.Price));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern40(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Autorzy") && queryModel.SortOrder.Equals("Cena malejąco");

        private static async Task<IPagedList<Book>> Match40(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.Author.Any(a => a.FirstName.Contains(queryModel.SearchString) || a.LastNameForDisplay.Contains(queryModel.SearchString)),
                    b => b.OrderByDescending(x => x.Price));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern41(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Wydawnictwa") && queryModel.SortOrder.Equals("Sortuj");

        private static async Task<IPagedList<Book>> Match41(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.Publishing.NameForDisplay.Contains(queryModel.SearchString),
                    b => b.OrderBy(x => x.Id));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern42(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Wydawnictwa") && queryModel.SortOrder.Equals("Tytuł A-Z");

        private static async Task<IPagedList<Book>> Match42(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.Publishing.NameForDisplay.Contains(queryModel.SearchString),
                    b => b.OrderBy(x => x.Title));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern43(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Wydawnictwa") && queryModel.SortOrder.Equals("Tytuł Z-A");

        private static async Task<IPagedList<Book>> Match43(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.Publishing.NameForDisplay.Contains(queryModel.SearchString),
                    b => b.OrderByDescending(x => x.Title));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern44(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Wydawnictwa") && queryModel.SortOrder.Equals("Cena rosnąco");

        private static async Task<IPagedList<Book>> Match44(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.Publishing.NameForDisplay.Contains(queryModel.SearchString),
                    b => b.OrderBy(x => x.Price));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }

        private static bool Pattern45(QueryStringSearch queryModel)
            => queryModel.SearchOption.Equals("Wydawnictwa") && queryModel.SortOrder.Equals("Cena malejąco");

        private static async Task<IPagedList<Book>> Match45(QueryStringSearch queryModel)
        {
            var books =
                await _unitOfWork.BookRepository.FindAll(b => b.Quantity > 0 && b.Publishing.NameForDisplay.Contains(queryModel.SearchString),
                    b => b.OrderByDescending(x => x.Price));

            return books.ToPagedList(queryModel.Page, queryModel.ItemsPerPage);
        }
    }
}