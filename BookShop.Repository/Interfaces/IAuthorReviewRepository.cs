using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BookShop.Data;

namespace BookShop.Repository.Interfaces
{
    public interface IAuthorReviewRepository : IGenericRepository<AuthorReview>
    {
        IEnumerable<AuthorReview> FindAllSync(Expression<Func<AuthorReview, bool>> filter,
            Func<IQueryable<AuthorReview>, IOrderedQueryable<AuthorReview>> orderBy = null,
            int? skip = null, int? take = null);
    }
}