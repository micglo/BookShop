using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Data.Sql;
using BookShop.Repository.Interfaces;

namespace BookShop.Repository
{
    public class SubMainCategoryRepository : GenericRepository<SubMainCategory>, ISubMainCategoryRepository
    {
        public SubMainCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task Update(SubMainCategory entity)
        {
            var local = Context.Set<SubMainCategory>()
                .Local
                .FirstOrDefault(s => s.Id == entity.Id);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            await base.Update(entity);
        }

        public override async Task Remove(SubMainCategory entity)
        {
            var local = Context.Set<SubMainCategory>()
                .Local
                .FirstOrDefault(s => s.Id == entity.Id);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            await base.Remove(entity);
        }


        /// <summary>
        /// Sztywne nie asynchroniczne zapytanie, aby wyświetlic dane synchronicznie
        /// </summary>
        /// <param name="orderBy"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public IEnumerable<SubMainCategory> GetAllCategories(
            Func<IQueryable<SubMainCategory>, IOrderedQueryable<SubMainCategory>> orderBy = null,
            int? skip = null, int? take = null) 
            => GetQueryable(null, orderBy, skip, take).ToList();
    }
}