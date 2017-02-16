using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BookShop.Data;

namespace BookShop.Repository.Interfaces
{
    public interface IBookReviewRepository : IGenericRepository<BookReview>
    {
        IEnumerable<BookReview> FindAllSync(Expression<Func<BookReview, bool>> filter,
            Func<IQueryable<BookReview>, IOrderedQueryable<BookReview>> orderBy = null,
            int? skip = null, int? take = null);
    }
}