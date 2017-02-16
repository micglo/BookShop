using System.Data.Entity;
using System.Linq;
using BookShop.Common.Repository.Interfaces;
using BookShop.Data;
using BookShop.Data.Sql;

namespace BookShop.Common.Repository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override void Update(Book entity)
        {
            var local = Context.Set<Book>()
                .Local
                .FirstOrDefault(b => b.BookId == entity.BookId);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            base.Update(entity);
        }

        public override void Remove(Book entity)
        {
            var local = Context.Set<Book>()
                .Local
                .FirstOrDefault(b => b.BookId == entity.BookId);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            base.Remove(entity);
        }
    }
}