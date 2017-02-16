using System;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Models.QueryString;

namespace BookShop.Service.PatternMatching.BookSearch
{
    /// <summary>
    /// Pattern match odpowiedzialny za powiązanie wyszukiwanego elementu z wynikiem wyszukiwania
    /// Przeszukuje liste wg określonych wzorów i jeśli znajdzie odpowiedni wzór to realizuje odpowiedź
    /// </summary>
    public class PatternMatchBookSearch
    {
        private readonly Func<QueryStringSearch, bool> _patternQueryString;
        private readonly Func<QueryStringSearch, Task<PagedList.IPagedList<Book>>> _matchQueryString;

        public PatternMatchBookSearch(Func<QueryStringSearch, bool> pattern
            , Func<QueryStringSearch, Task<PagedList.IPagedList<Book>>> match)
        {
            _patternQueryString = pattern;
            _matchQueryString = match;
        }


        /// <summary>
        /// Powiązanie dla wzorca
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public bool CheckPatternQueryString(QueryStringSearch queryModel) 
            => _patternQueryString(queryModel);


        /// <summary>
        /// Powiązanie dla wyniku
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public Task<PagedList.IPagedList<Book>> UseMatchQueryString(QueryStringSearch queryModel) 
            => _matchQueryString(queryModel);
    }
}