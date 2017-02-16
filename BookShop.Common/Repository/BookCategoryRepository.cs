using System.Data.Entity;
using System.Linq;
using BookShop.Common.Repository.Interfaces;
using BookShop.Data;
using BookShop.Data.Sql;

namespace BookShop.Common.Repository
{
    public class BookCategoryRepository : GenericRepository<BookCategory>, IBookCategoryRepository
    {
        public BookCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override void Update(BookCategory entity)
        {
            var local = Context.Set<BookCategory>()
                .Local
                .FirstOrDefault(b => b.BookCategoryId == entity.BookCategoryId);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            base.Update(entity);
        }

        public override void Remove(BookCategory entity)
        {
            var local = Context.Set<BookCategory>()
                .Local
                .FirstOrDefault(b => b.BookCategoryId == entity.BookCategoryId);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            base.Remove(entity);
        }
    }
}