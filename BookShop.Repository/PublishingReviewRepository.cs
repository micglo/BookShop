using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Data.Sql;
using BookShop.Repository.Interfaces;

namespace BookShop.Repository
{
    public class PublishingReviewRepository : GenericRepository<PublishingReview>, IPublishingReviewRepository
    {
        public PublishingReviewRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task Update(PublishingReview entity)
        {
            var local = Context.Set<PublishingReview>()
                .Local
                .FirstOrDefault(p => p.Id == entity.Id);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            await base.Update(entity);
        }

        public override async Task Remove(PublishingReview entity)
        {
            var local = Context.Set<PublishingReview>()
                .Local
                .FirstOrDefault(p => p.Id == entity.Id);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            await base.Remove(entity);
        }


        /// <summary>
        /// Sztywne nie asynchroniczne zapytanie, aby wyświetlic dane synchronicznie
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public IEnumerable<PublishingReview> FindAllSync(Expression<Func<PublishingReview, bool>> filter,
            Func<IQueryable<PublishingReview>, IOrderedQueryable<PublishingReview>> orderBy = null,
            int? skip = null, int? take = null) 
            => GetQueryable(filter, orderBy, skip, take).ToList();
    }
}