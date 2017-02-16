using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using BookShop.Data.Sql;
using BookShop.Repository.Interfaces;

namespace BookShop.Repository
{
    public class BookCategoryRepository : GenericRepository<BookCategory>, IBookCategoryRepository
    {
        public BookCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task Update(BookCategory entity)
        {
            var local = Context.Set<BookCategory>()
                .Local
                .FirstOrDefault(b => b.Id == entity.Id);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            await base.Update(entity);
        }

        public override async Task Remove(BookCategory entity)
        {
            var local = Context.Set<BookCategory>()
                .Local
                .FirstOrDefault(b => b.Id == entity.Id);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            await base.Remove(entity);
        }
    }
}