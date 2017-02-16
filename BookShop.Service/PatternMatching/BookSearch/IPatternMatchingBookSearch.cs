using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Models.QueryString;
using PagedList;

namespace BookShop.Service.PatternMatching.BookSearch
{
    public interface IPatternMatchingBookSearch
    {
        Task<IPagedList<Book>> PatternMatchingQueryString(QueryStringSearch queryModel);
    }
}