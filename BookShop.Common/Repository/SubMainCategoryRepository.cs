using System.Data.Entity;
using System.Linq;
using BookShop.Common.Repository.Interfaces;
using BookShop.Data;
using BookShop.Data.Sql;

namespace BookShop.Common.Repository
{
    public class SubMainCategoryRepository : GenericRepository<SubMainCategory>, ISubMainCategoryRepository
    {
        public SubMainCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override void Update(SubMainCategory entity)
        {
            var local = Context.Set<SubMainCategory>()
                .Local
                .FirstOrDefault(s => s.SubMainCategoryId == entity.SubMainCategoryId);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            base.Update(entity);
        }

        public override void Remove(SubMainCategory entity)
        {
            var local = Context.Set<SubMainCategory>()
                .Local
                .FirstOrDefault(s => s.SubMainCategoryId == entity.SubMainCategoryId);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            base.Remove(entity);
        }
    }
}