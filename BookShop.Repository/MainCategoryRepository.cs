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
    public class MainCategoryRepository : GenericRepository<MainCategory>, IMainCategoryRepository
    {
        public MainCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task Update(MainCategory entity)
        {
            var local = Context.Set<MainCategory>()
                .Local
                .FirstOrDefault(m => m.Id == entity.Id);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            await base.Update(entity);
        }

        public override async Task Remove(MainCategory entity)
        {
            var local = Context.Set<MainCategory>()
                .Local
                .FirstOrDefault(m => m.Id == entity.Id);

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
        public IEnumerable<MainCategory> GetAllCategories(
            Func<IQueryable<MainCategory>, IOrderedQueryable<MainCategory>> orderBy = null,
            int? skip = null, int? take = null) 
            => GetQueryable(null, orderBy, skip, take).ToList();
    }
}