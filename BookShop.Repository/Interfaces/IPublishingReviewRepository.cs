using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BookShop.Data;

namespace BookShop.Repository.Interfaces
{
    public interface IPublishingReviewRepository : IGenericRepository<PublishingReview>
    {
        IEnumerable<PublishingReview> FindAllSync(Expression<Func<PublishingReview, bool>> filter,
            Func<IQueryable<PublishingReview>, IOrderedQueryable<PublishingReview>> orderBy = null,
            int? skip = null, int? take = null);
    }
}