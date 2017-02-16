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
    public class AuthorReviewRepository : GenericRepository<AuthorReview>, IAuthorReviewRepository
    {
        public AuthorReviewRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task Update(AuthorReview entity)
        {
            var local = Context.Set<AuthorReview>()
                .Local
                .FirstOrDefault(a => a.Id == entity.Id);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            await base.Update(entity);
        }

        public override async Task Remove(AuthorReview entity)
        {
            var local = Context.Set<AuthorReview>()
                .Local
                .FirstOrDefault(a => a.Id == entity.Id);

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
        public IEnumerable<AuthorReview> FindAllSync(Expression<Func<AuthorReview, bool>> filter,
            Func<IQueryable<AuthorReview>, IOrderedQueryable<AuthorReview>> orderBy = null,
            int? skip = null, int? take = null) 
            => GetQueryable(filter, orderBy, skip, take).ToList();
    }
}