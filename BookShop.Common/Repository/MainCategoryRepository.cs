using System.Data.Entity;
using System.Linq;
using BookShop.Common.Repository.Interfaces;
using BookShop.Data;
using BookShop.Data.Sql;

namespace BookShop.Common.Repository
{
    public class MainCategoryRepository : GenericRepository<MainCategory>, IMainCategoryRepository
    {
        public MainCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override void Update(MainCategory entity)
        {
            var local = Context.Set<MainCategory>()
                .Local
                .FirstOrDefault(m => m.MainCategoryId == entity.MainCategoryId);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            base.Update(entity);
        }

        public override void Remove(MainCategory entity)
        {
            var local = Context.Set<MainCategory>()
                .Local
                .FirstOrDefault(m => m.MainCategoryId == entity.MainCategoryId);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            base.Remove(entity);
        }
    }
}