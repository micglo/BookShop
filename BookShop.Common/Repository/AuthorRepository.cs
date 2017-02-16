using System.Data.Entity;
using System.Linq;
using BookShop.Common.Repository.Interfaces;
using BookShop.Data;
using BookShop.Data.Sql;

namespace BookShop.Common.Repository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override void Update(Author entity)
        {
            var local = Context.Set<Author>()
                .Local
                .FirstOrDefault(a => a.AuthorId == entity.AuthorId);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            base.Update(entity);
        }

        public override void Remove(Author entity)
        {
            var local = Context.Set<Author>()
                .Local
                .FirstOrDefault(a => a.AuthorId == entity.AuthorId);

            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            base.Remove(entity);
        }
    }
}